using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;

namespace NK_COLLECTION.Negocios.Catalogos
{
    public class Proveedor_Service
    {
        private readonly DbContextOptions<NkCollectionContext> _options;

        public Proveedor_Service(DbContextOptions<NkCollectionContext> options)
        {
            _options = options;
        }

        // GUARDAR PROVEEDOR
        public async Task GuardarAsync(
            string nombre,
            string? telefono,
            string? correo,
            string? direccion,
            string? ruc)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Ingrese el nombre del proveedor.");

            nombre = nombre.Trim();

            telefono = string.IsNullOrWhiteSpace(telefono)
                ? null
                : telefono.Trim();

            correo = string.IsNullOrWhiteSpace(correo)
                ? null
                : correo.Trim();

            direccion = string.IsNullOrWhiteSpace(direccion)
                ? null
                : direccion.Trim();

            ruc = string.IsNullOrWhiteSpace(ruc)
                ? null
                : ruc.Trim();

            await using var contexto = new NkCollectionContext(_options);

            // VALIDAR RUC DUPLICADO
            if (ruc != null)
            {
                bool existeRuc = await contexto.Proveedors
                    .AnyAsync(p => p.Ruc == ruc);

                if (existeRuc)
                    throw new Exception(
                        "El RUC ya está registrado.");
            }

            var proveedor = new Proveedor
            {
                Nombre = nombre,
                Telefono = telefono,
                Correo = correo,
                Direccion = direccion,
                Ruc = ruc,
                Estado = true,
                FechaRegistro = DateTime.Now
            };

            contexto.Proveedors.Add(proveedor);

            await contexto.SaveChangesAsync();
        }

        // LISTAR PROVEEDORES
        public async Task<List<Proveedor>> ListarAsync()
        {
            await using var contexto = new NkCollectionContext(_options);

            return await contexto.Proveedors
                .AsNoTracking()
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        // BUSCAR PROVEEDORES
        public async Task<List<Proveedor>> BuscarAsync(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return await ListarAsync();

            texto = texto.Trim();

            await using var contexto = new NkCollectionContext(_options);

            return await contexto.Proveedors
                .AsNoTracking()
                .Where(p =>
                    EF.Functions.ILike(
                        p.Nombre,
                        $"%{texto}%") ||

                    (p.Ruc != null &&
                     EF.Functions.ILike(
                         p.Ruc,
                         $"%{texto}%")) ||

                    (p.Telefono != null &&
                     EF.Functions.ILike(
                         p.Telefono,
                         $"%{texto}%")) ||

                    (p.Correo != null &&
                     EF.Functions.ILike(
                         p.Correo,
                         $"%{texto}%")))
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        // OBTENER PROVEEDOR POR ID
        public async Task<Proveedor?> ObtenerPorIdAsync(
            int idProveedor)
        {
            await using var contexto = new NkCollectionContext(_options);

            return await contexto.Proveedors
                .AsNoTracking()
                .FirstOrDefaultAsync(p =>
                    p.IdProveedor == idProveedor);
        }

        // EDITAR PROVEEDOR
        public async Task EditarAsync(
            int idProveedor,
            string nombre,
            string? telefono,
            string? correo,
            string? direccion,
            string? ruc)
        {
            if (idProveedor <= 0)
                throw new Exception("Proveedor no válido.");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Ingrese el nombre del proveedor.");

            nombre = nombre.Trim();

            telefono = string.IsNullOrWhiteSpace(telefono)
                ? null
                : telefono.Trim();

            correo = string.IsNullOrWhiteSpace(correo)
                ? null
                : correo.Trim();

            direccion = string.IsNullOrWhiteSpace(direccion)
                ? null
                : direccion.Trim();

            ruc = string.IsNullOrWhiteSpace(ruc)
                ? null
                : ruc.Trim();

            await using var contexto = new NkCollectionContext(_options);

            var proveedor = await contexto.Proveedors
                .FirstOrDefaultAsync(p =>
                    p.IdProveedor == idProveedor);

            if (proveedor == null)
                throw new Exception("El proveedor no existe.");

            // VALIDAR RUC DUPLICADO
            if (ruc != null)
            {
                bool existeRuc = await contexto.Proveedors
                    .AnyAsync(p =>
                        p.Ruc == ruc &&
                        p.IdProveedor != idProveedor);

                if (existeRuc)
                    throw new Exception(
                        "El RUC ya está registrado en otro proveedor.");
            }

            proveedor.Nombre = nombre;
            proveedor.Telefono = telefono;
            proveedor.Correo = correo;
            proveedor.Direccion = direccion;
            proveedor.Ruc = ruc;

            await contexto.SaveChangesAsync();
        }

        // CAMBIAR ESTADO
        public async Task CambiarEstadoAsync(
            int idProveedor,
            bool estado)
        {
            await using var contexto = new NkCollectionContext(_options);

            var proveedor = await contexto.Proveedors
                .FirstOrDefaultAsync(p =>
                    p.IdProveedor == idProveedor);

            if (proveedor == null)
                throw new Exception("El proveedor no existe.");

            proveedor.Estado = estado;

            await contexto.SaveChangesAsync();
        }

        // DESACTIVAR PROVEEDOR
        public async Task DesactivarAsync(int idProveedor)
        {
            await CambiarEstadoAsync(idProveedor, false);
        }

        // ACTIVAR PROVEEDOR
        public async Task ActivarAsync(int idProveedor)
        {
            await CambiarEstadoAsync(idProveedor, true);
        }
    }
}