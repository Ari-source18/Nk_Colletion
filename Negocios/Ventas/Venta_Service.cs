using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;

namespace NK_COLLECTION.Negocios.Ventas
{
    public class Venta_Service
    {
        private readonly DbContextOptions<NkCollectionContext> _options;

        public Venta_Service(DbContextOptions<NkCollectionContext> options)
        {
            _options = options;
        }

        
        // REGISTRAR VENTA
        public async Task<Ventum> GuardarVentaAsync(
            Ventum venta,
            List<PagoVentum> pagos)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            if (venta.DetalleVenta == null || !venta.DetalleVenta.Any())
                throw new Exception("Debe agregar al menos un producto a la venta.");

            if (pagos == null || !pagos.Any())
                throw new Exception("Debe registrar al menos un método de pago.");

            if (venta.TotalVenta <= 0)
                throw new Exception("El total de la venta debe ser mayor que cero.");

            decimal totalPagado = pagos.Sum(p => p.Monto);

            if (totalPagado < venta.TotalVenta)
                throw new Exception(
                    $"El monto pagado es insuficiente. Total de venta: C${venta.TotalVenta:N2}, " +
                    $"pagado: C${totalPagado:N2}");

            await using var context = new NkCollectionContext(_options);

            await using var transaction =
                await context.Database.BeginTransactionAsync();

            try
            {
                // Datos automáticos
                venta.FechaVenta ??= DateTime.Now;
                venta.Estado ??= true;

                
                // GUARDAR VENTA Y DETALLES
                context.Set<Ventum>().Add(venta);

                // Esto genera el IdVenta
                await context.SaveChangesAsync();

                
                // GUARDAR PAGOS
                
                foreach (var pago in pagos)
                {
                    if (pago.Monto <= 0)
                        throw new Exception(
                            "Todos los pagos deben tener un monto mayor que cero.");

                    pago.IdVenta = venta.IdVenta;
                    pago.FechaPago ??= DateTime.Now;

                    context.Set<PagoVentum>().Add(pago);
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return venta;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        
        // OBTENER TODAS LAS VENTAS
        
        public async Task<List<Ventum>> ObtenerVentasAsync()
        {
            await using var context = new NkCollectionContext(_options);

            return await context.Set<Ventum>()
                .AsNoTracking()
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdAperturaCajaNavigation)
                .Include(v => v.DetalleVenta)
                .Include(v => v.PagoVenta)
                    .ThenInclude(p => p.IdMetodoPagoNavigation)
                .OrderByDescending(v => v.FechaVenta)
                .ToListAsync();
        }

        
        // BUSCAR VENTA POR ID
        
        public async Task<Ventum?> ObtenerVentaPorIdAsync(int idVenta)
        {
            if (idVenta <= 0)
                return null;

            await using var context = new NkCollectionContext(_options);

            return await context.Set<Ventum>()
                .AsNoTracking()
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdAperturaCajaNavigation)
                .Include(v => v.DetalleVenta)
                .Include(v => v.PagoVenta)
                    .ThenInclude(p => p.IdMetodoPagoNavigation)
                .FirstOrDefaultAsync(v => v.IdVenta == idVenta);
        }

        
        // BUSCAR POR NÚMERO DE COMPROBANTE
        public async Task<Ventum?> BuscarPorComprobanteAsync(
            string numeroComprobante)
        {
            if (string.IsNullOrWhiteSpace(numeroComprobante))
                return null;

            numeroComprobante = numeroComprobante.Trim();

            await using var context = new NkCollectionContext(_options);

            return await context.Set<Ventum>()
                .AsNoTracking()
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.DetalleVenta)
                .Include(v => v.PagoVenta)
                    .ThenInclude(p => p.IdMetodoPagoNavigation)
                .FirstOrDefaultAsync(
                    v => v.NumeroComprobante == numeroComprobante);
        }

        
        // GENERAR NÚMERO DE COMPROBANTE
        public async Task<string> GenerarNumeroComprobanteAsync()
        {
            await using var context = new NkCollectionContext(_options);

            int ultimoId = await context.Set<Ventum>()
                .MaxAsync(v => (int?)v.IdVenta) ?? 0;

            int siguiente = ultimoId + 1;

            return $"V-{siguiente:D6}";
        }

        // ANULAR VENTA
        
        public async Task<bool> AnularVentaAsync(int idVenta)
        {
            if (idVenta <= 0)
                return false;

            await using var context = new NkCollectionContext(_options);

            var venta = await context.Set<Ventum>()
                .FirstOrDefaultAsync(v => v.IdVenta == idVenta);

            if (venta == null)
                return false;

            venta.Estado = false;

            await context.SaveChangesAsync();

            return true;
        }

        
        // VERIFICAR SI EXISTE COMPROBANTE
        public async Task<bool> ExisteComprobanteAsync(
            string numeroComprobante)
        {
            if (string.IsNullOrWhiteSpace(numeroComprobante))
                return false;

            await using var context = new NkCollectionContext(_options);

            return await context.Set<Ventum>()
                .AnyAsync(v =>
                    v.NumeroComprobante == numeroComprobante.Trim());
        }

        
        // OBTENER VENTAS ACTIVAS
        
        public async Task<List<Ventum>> ObtenerVentasActivasAsync()
        {
            await using var context = new NkCollectionContext(_options);

            return await context.Set<Ventum>()
                .AsNoTracking()
                .Include(v => v.IdClienteNavigation)
                .Where(v => v.Estado == true)
                .OrderByDescending(v => v.FechaVenta)
                .ToListAsync();
        }

        // OBTENER VENTAS POR FECHA
        public async Task<List<Ventum>> ObtenerVentasPorFechaAsync(
            DateTime fecha)
        {
            DateTime inicio = fecha.Date;
            DateTime fin = inicio.AddDays(1);

            await using var context = new NkCollectionContext(_options);

            return await context.Set<Ventum>()
                .AsNoTracking()
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.PagoVenta)
                .Where(v =>
                    v.FechaVenta >= inicio &&
                    v.FechaVenta < fin &&
                    v.Estado == true)
                .OrderByDescending(v => v.FechaVenta)
                .ToListAsync();
        }
    }
}