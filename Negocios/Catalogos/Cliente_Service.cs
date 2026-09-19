using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;

namespace NK_COLLECTION.Negocios.Catalogos
{
    public class Cliente_Service
    {
        private readonly DbContextOptions<NkCollectionContext> _options;

        public Cliente_Service(DbContextOptions<NkCollectionContext> options)
        {
            _options = options;
        }

        // GUARDAR CLIENTE
        public async Task GuardarAsync(
            string? cedula,
            string nombre,
            string apellido,
            string? telefono,
            string? correo,
            string? direccion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Ingrese el nombre del cliente.");

            if (string.IsNullOrWhiteSpace(apellido))
                throw new Exception("Ingrese el apellido del cliente.");

            nombre = nombre.Trim();
            apellido = apellido.Trim();

            cedula = string.IsNullOrWhiteSpace(cedula)
                ? null
                : cedula.Trim();

            telefono = string.IsNullOrWhiteSpace(telefono)
                ? null
                : telefono.Trim();

            correo = string.IsNullOrWhiteSpace(correo)
                ? null
                : correo.Trim();

            direccion = string.IsNullOrWhiteSpace(direccion)
                ? null
                : direccion.Trim();

            await using var contexto = new NkCollectionContext(_options);

            // VALIDAR CÉDULA DUPLICADA
            if (cedula != null)
            {
                bool existeCedula = await contexto.Clientes
                    .AnyAsync(c => c.Cedula == cedula);

                if (existeCedula)
                    throw new Exception(
                        "La cédula ya está registrada.");
            }

            var cliente = new Cliente
            {
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                Correo = correo,
                Direccion = direccion,
                FechaRegistro = DateTime.Now,
                Estado = true
            };

            contexto.Clientes.Add(cliente);

            await contexto.SaveChangesAsync();
        }

        // LISTAR CLIENTES
        public async Task<List<Cliente>> ListarAsync()
        {
            await using var contexto = new NkCollectionContext(_options);

            return await contexto.Clientes
                .AsNoTracking()
                .OrderBy(c => c.Nombre)
                .ThenBy(c => c.Apellido)
                .ToListAsync();
        }

        // BUSCAR CLIENTES
        public async Task<List<Cliente>> BuscarAsync(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return await ListarAsync();

            texto = texto.Trim();

            await using var contexto = new NkCollectionContext(_options);

            return await contexto.Clientes
                .AsNoTracking()
                .Where(c =>
                    EF.Functions.ILike(
                        c.Nombre,
                        $"%{texto}%") ||

                    EF.Functions.ILike(
                        c.Apellido,
                        $"%{texto}%") ||

                    (c.Cedula != null &&
                     EF.Functions.ILike(
                         c.Cedula,
                         $"%{texto}%")) ||

                    (c.Telefono != null &&
                     EF.Functions.ILike(
                         c.Telefono,
                         $"%{texto}%")) ||

                    (c.Correo != null &&
                     EF.Functions.ILike(
                         c.Correo,
                         $"%{texto}%")))
                .OrderBy(c => c.Nombre)
                .ThenBy(c => c.Apellido)
                .ToListAsync();
        }

        // OBTENER CLIENTE POR ID
        public async Task<Cliente?> ObtenerPorIdAsync(
            int idCliente)
        {
            await using var contexto = new NkCollectionContext(_options);

            return await contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c =>
                    c.IdCliente == idCliente);
        }

        // EDITAR CLIENTE
        public async Task EditarAsync(
            int idCliente,
            string? cedula,
            string nombre,
            string apellido,
            string? telefono,
            string? correo,
            string? direccion)
        {
            if (idCliente <= 0)
                throw new Exception("Cliente no válido.");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Ingrese el nombre del cliente.");

            if (string.IsNullOrWhiteSpace(apellido))
                throw new Exception("Ingrese el apellido del cliente.");

            nombre = nombre.Trim();
            apellido = apellido.Trim();

            cedula = string.IsNullOrWhiteSpace(cedula)
                ? null
                : cedula.Trim();

            telefono = string.IsNullOrWhiteSpace(telefono)
                ? null
                : telefono.Trim();

            correo = string.IsNullOrWhiteSpace(correo)
                ? null
                : correo.Trim();

            direccion = string.IsNullOrWhiteSpace(direccion)
                ? null
                : direccion.Trim();

            await using var contexto = new NkCollectionContext(_options);

            var cliente = await contexto.Clientes
                .FirstOrDefaultAsync(c =>
                    c.IdCliente == idCliente);

            if (cliente == null)
                throw new Exception("El cliente no existe.");

            // VALIDAR CÉDULA DUPLICADA
            if (cedula != null)
            {
                bool existeCedula = await contexto.Clientes
                    .AnyAsync(c =>
                        c.Cedula == cedula &&
                        c.IdCliente != idCliente);

                if (existeCedula)
                    throw new Exception(
                        "La cédula ya está registrada en otro cliente.");
            }

            cliente.Cedula = cedula;
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Telefono = telefono;
            cliente.Correo = correo;
            cliente.Direccion = direccion;

            await contexto.SaveChangesAsync();
        }

        // CAMBIAR ESTADO
        public async Task CambiarEstadoAsync(
            int idCliente,
            bool estado)
        {
            await using var contexto = new NkCollectionContext(_options);

            var cliente = await contexto.Clientes
                .FirstOrDefaultAsync(c =>
                    c.IdCliente == idCliente);

            if (cliente == null)
                throw new Exception("El cliente no existe.");

            cliente.Estado = estado;

            await contexto.SaveChangesAsync();
        }

        // DESACTIVAR CLIENTE
        public async Task DesactivarAsync(int idCliente)
        {
            await CambiarEstadoAsync(idCliente, false);
        }

        // ACTIVAR CLIENTE
        public async Task ActivarAsync(int idCliente)
        {
            await CambiarEstadoAsync(idCliente, true);
        }
    }
}