using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;

namespace NK_COLLECTION.Negocios.Caja
{
    public class Egreso_Service
    {
        private readonly DbContextOptions<NkCollectionContext> _options;

        public Egreso_Service(DbContextOptions<NkCollectionContext> options)
        {
            _options = options;
        }

        // GUARDAR EGRESO
        public async Task GuardarAsync(
            int idAperturaCaja,
            int idTipoEgreso,
            decimal monto,
            string? descripcion)
        {
            if (idAperturaCaja <= 0)
                throw new Exception(
                    "No existe una apertura de caja válida.");

            if (idTipoEgreso <= 0)
                throw new Exception(
                    "Seleccione un tipo de egreso.");

            if (monto <= 0)
                throw new Exception(
                    "El monto del egreso debe ser mayor que cero.");

            descripcion = string.IsNullOrWhiteSpace(descripcion)
                ? null
                : descripcion.Trim();

            if (descripcion != null &&
                descripcion.Length > 250)
            {
                throw new Exception(
                    "La descripción no puede superar los 250 caracteres.");
            }

            await using var contexto =
                new NkCollectionContext(_options);

            // VALIDAR APERTURA DE CAJA
            bool existeApertura = await contexto.AperturaCajas
                .AnyAsync(a =>
                    a.IdAperturaCaja == idAperturaCaja &&
                    a.Estado == true);

            if (!existeApertura)
                throw new Exception(
                    "La caja no se encuentra abierta.");

            // VALIDAR TIPO DE EGRESO
            bool existeTipo = await contexto.TipoEgresos
                .AnyAsync(t =>
                    t.IdTipoEgreso == idTipoEgreso &&
                    t.Estado == true);

            if (!existeTipo)
                throw new Exception(
                    "El tipo de egreso seleccionado no existe o está inactivo.");

            var egreso = new Egreso
            {
                IdAperturaCaja = idAperturaCaja,
                IdTipoEgreso = idTipoEgreso,
                Monto = monto,
                Descripcion = descripcion,
                FechaEgreso = DateTime.Now,
                Estado = true
            };

            contexto.Egresos.Add(egreso);

            await contexto.SaveChangesAsync();
        }


        // LISTAR EGRESOS
        public async Task<List<Egreso>> ListarAsync()
        {
            await using var contexto =
                new NkCollectionContext(_options);

            return await contexto.Egresos
                .AsNoTracking()
                .Include(e => e.IdTipoEgresoNavigation)
                .OrderByDescending(e => e.FechaEgreso)
                .ToListAsync();
        }


        // LISTAR EGRESOS ACTIVOS
        public async Task<List<Egreso>> ListarActivosAsync()
        {
            await using var contexto =
                new NkCollectionContext(_options);

            return await contexto.Egresos
                .AsNoTracking()
                .Include(e => e.IdTipoEgresoNavigation)
                .Where(e => e.Estado == true)
                .OrderByDescending(e => e.FechaEgreso)
                .ToListAsync();
        }


        // BUSCAR EGRESOS
        public async Task<List<Egreso>> BuscarAsync(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return await ListarAsync();

            texto = texto.Trim();

            await using var contexto =
                new NkCollectionContext(_options);

            return await contexto.Egresos
                .AsNoTracking()
                .Include(e => e.IdTipoEgresoNavigation)
                .Where(e =>
                    (e.Descripcion != null &&
                     EF.Functions.ILike(
                         e.Descripcion,
                         $"%{texto}%")) ||

                    EF.Functions.ILike(
                        e.IdTipoEgresoNavigation.Nombre,
                        $"%{texto}%"))
                .OrderByDescending(e => e.FechaEgreso)
                .ToListAsync();
        }


        // OBTENER EGRESO POR ID
        public async Task<Egreso?> ObtenerPorIdAsync(
            int idEgreso)
        {
            await using var contexto =
                new NkCollectionContext(_options);

            return await contexto.Egresos
                .AsNoTracking()
                .Include(e => e.IdTipoEgresoNavigation)
                .FirstOrDefaultAsync(e =>
                    e.IdEgreso == idEgreso);
        }


        // EDITAR EGRESO
        public async Task EditarAsync(
            int idEgreso,
            int idTipoEgreso,
            decimal monto,
            string? descripcion)
        {
            if (idEgreso <= 0)
                throw new Exception(
                    "Egreso no válido.");

            if (idTipoEgreso <= 0)
                throw new Exception(
                    "Seleccione un tipo de egreso.");

            if (monto <= 0)
                throw new Exception(
                    "El monto debe ser mayor que cero.");

            descripcion = string.IsNullOrWhiteSpace(descripcion)
                ? null
                : descripcion.Trim();

            if (descripcion != null &&
                descripcion.Length > 250)
            {
                throw new Exception(
                    "La descripción no puede superar los 250 caracteres.");
            }

            await using var contexto =
                new NkCollectionContext(_options);

            var egreso = await contexto.Egresos
                .FirstOrDefaultAsync(e =>
                    e.IdEgreso == idEgreso);

            if (egreso == null)
                throw new Exception(
                    "El egreso no existe.");

            // VALIDAR TIPO DE EGRESO
            bool existeTipo = await contexto.TipoEgresos
                .AnyAsync(t =>
                    t.IdTipoEgreso == idTipoEgreso &&
                    t.Estado == true);

            if (!existeTipo)
                throw new Exception(
                    "El tipo de egreso seleccionado no existe o está inactivo.");

            egreso.IdTipoEgreso = idTipoEgreso;
            egreso.Monto = monto;
            egreso.Descripcion = descripcion;

            await contexto.SaveChangesAsync();
        }


        // CAMBIAR ESTADO
        public async Task CambiarEstadoAsync(
            int idEgreso,
            bool estado)
        {
            await using var contexto =
                new NkCollectionContext(_options);

            var egreso = await contexto.Egresos
                .FirstOrDefaultAsync(e =>
                    e.IdEgreso == idEgreso);

            if (egreso == null)
                throw new Exception(
                    "El egreso no existe.");

            egreso.Estado = estado;

            await contexto.SaveChangesAsync();
        }


        // DESACTIVAR EGRESO
        public async Task DesactivarAsync(
            int idEgreso)
        {
            await CambiarEstadoAsync(
                idEgreso,
                false);
        }


        // ACTIVAR EGRESO
        public async Task ActivarAsync(
            int idEgreso)
        {
            await CambiarEstadoAsync(
                idEgreso,
                true);
        }


        // TOTAL DE DINERO EGRESADO
        public async Task<decimal> ObtenerTotalEgresadoAsync()
        {
            await using var contexto =
                new NkCollectionContext(_options);

            return await contexto.Egresos
                .Where(e => e.Estado == true)
                .SumAsync(e => e.Monto);
        }


        // CANTIDAD TOTAL DE EGRESOS
        public async Task<int> ObtenerCantidadEgresosAsync()
        {
            await using var contexto =
                new NkCollectionContext(_options);

            return await contexto.Egresos
                .CountAsync(e =>
                    e.Estado == true);
        }
    }
}