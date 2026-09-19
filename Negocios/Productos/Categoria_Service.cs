using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;

namespace NK_COLLECTION.Negocios.Catalogos
{
    public class Caregoria_Service
    {
        private readonly DbContextOptions<NkCollectionContext> _options;

        public Caregoria_Service(DbContextOptions<NkCollectionContext> options)
        {
            _options = options;
        }

        // GUARDAR CATEGORÍA
        public async Task GuardarAsync(
            string nombreCategoria,
            string? descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombreCategoria))
                throw new Exception("Ingrese el nombre de la categoría.");

            nombreCategoria = nombreCategoria.Trim();

            if (!string.IsNullOrWhiteSpace(descripcion))
                descripcion = descripcion.Trim();

            await using var contexto = new NkCollectionContext(_options);

            bool existe = await contexto.Categoria
                .AnyAsync(c =>
                    EF.Functions.ILike(
                        c.NombreCategoria,
                        nombreCategoria));

            if (existe)
                throw new Exception("La categoría ya está registrada.");

            var categoria = new Categorium
            {
                NombreCategoria = nombreCategoria,
                Descripcion = descripcion,
                Estado = true
            };

            contexto.Categoria.Add(categoria);

            await contexto.SaveChangesAsync();
        }

        // LISTAR CATEGORÍAS
        public async Task<List<Categorium>> ListarAsync()
        {
            await using var contexto = new NkCollectionContext(_options);

            return await contexto.Categoria
                .AsNoTracking()
                .OrderBy(c => c.NombreCategoria)
                .ToListAsync();
        }

        // BUSCAR CATEGORÍAS
        public async Task<List<Categorium>> BuscarAsync(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return await ListarAsync();

            texto = texto.Trim();

            await using var contexto = new NkCollectionContext(_options);

            return await contexto.Categoria
                .AsNoTracking()
                .Where(c =>
                    EF.Functions.ILike(
                        c.NombreCategoria,
                        $"%{texto}%") ||
                    (c.Descripcion != null &&
                     EF.Functions.ILike(
                         c.Descripcion,
                         $"%{texto}%")))
                .OrderBy(c => c.NombreCategoria)
                .ToListAsync();
        }

        // OBTENER CATEGORÍA POR ID
        public async Task<Categorium?> ObtenerPorIdAsync(
            int idCategoria)
        {
            await using var contexto = new NkCollectionContext(_options);

            return await contexto.Categoria
                .AsNoTracking()
                .FirstOrDefaultAsync(c =>
                    c.IdCategoria == idCategoria);
        }

        // EDITAR CATEGORÍA
        public async Task EditarAsync(
            int idCategoria,
            string nombreCategoria,
            string? descripcion)
        {
            if (idCategoria <= 0)
                throw new Exception("Categoría no válida.");

            if (string.IsNullOrWhiteSpace(nombreCategoria))
                throw new Exception("Ingrese el nombre de la categoría.");

            nombreCategoria = nombreCategoria.Trim();

            if (!string.IsNullOrWhiteSpace(descripcion))
                descripcion = descripcion.Trim();

            await using var contexto = new NkCollectionContext(_options);

            var categoria = await contexto.Categoria
                .FirstOrDefaultAsync(c =>
                    c.IdCategoria == idCategoria);

            if (categoria == null)
                throw new Exception("La categoría no existe.");

            bool existe = await contexto.Categoria
                .AnyAsync(c =>
                    EF.Functions.ILike(
                        c.NombreCategoria,
                        nombreCategoria) &&
                    c.IdCategoria != idCategoria);

            if (existe)
                throw new Exception(
                    "Ya existe otra categoría con ese nombre.");

            categoria.NombreCategoria = nombreCategoria;
            categoria.Descripcion = descripcion;

            await contexto.SaveChangesAsync();
        }

        // CAMBIAR ESTADO
        public async Task CambiarEstadoAsync(
            int idCategoria,
            bool estado)
        {
            await using var contexto = new NkCollectionContext(_options);

            var categoria = await contexto.Categoria
                .FirstOrDefaultAsync(c =>
                    c.IdCategoria == idCategoria);

            if (categoria == null)
                throw new Exception("La categoría no existe.");

            categoria.Estado = estado;

            await contexto.SaveChangesAsync();
        }

        // DESACTIVAR CATEGORÍA
        public async Task DesactivarAsync(int idCategoria)
        {
            await CambiarEstadoAsync(idCategoria, false);
        }

        // ACTIVAR CATEGORÍA
        public async Task ActivarAsync(int idCategoria)
        {
            await CambiarEstadoAsync(idCategoria, true);
        }
    }
}