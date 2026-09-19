using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;

namespace NK_COLLECTION.Negocios.Catalogos;

public sealed record VarianteNueva(int? IdTalla, int? IdColor, int StockActual, int StockMinimo, decimal PrecioCompra, decimal PrecioVenta);

public class Producto_Service
{
    private readonly DbContextOptions<NkCollectionContext> _options;
    public Producto_Service(DbContextOptions<NkCollectionContext> options) => _options = options;

    public async Task<List<ProductoVariante>> ListarAsync()
    {
        await using var db = new NkCollectionContext(_options);
        return await db.ProductoVariantes.AsNoTracking()
            .Include(v => v.IdProductoNavigation).ThenInclude(p => p.IdCategoriaNavigation)
            .Include(v => v.IdProductoNavigation).ThenInclude(p => p.IdMarcaNavigation)
            .Include(v => v.IdColorNavigation).Include(v => v.IdTallaNavigation)
            .OrderBy(v => v.IdProducto).ThenBy(v => v.IdVariante).ToListAsync();
    }

    public async Task<int> GuardarProductoConVariantesAsync(string nombre, string? descripcion, int? categoria, int? marca, IReadOnlyCollection<VarianteNueva> variantes)
    {
        nombre = nombre.Trim();
        if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("Ingrese el nombre del producto.");
        if (variantes.Count == 0) throw new Exception("Agregue al menos una variante.");
        if (variantes.Any(v => v.StockActual < 0 || v.StockMinimo < 0 || v.PrecioCompra < 0 || v.PrecioVenta < 0))
            throw new Exception("Stock y precios no pueden ser negativos.");

        var repetidas = variantes.GroupBy(v => new { v.IdTalla, v.IdColor }).Any(g => g.Count() > 1);
        if (repetidas) throw new Exception("No puede repetir la misma combinación de talla y color para un producto.");

        await using var db = new NkCollectionContext(_options);
        await using var tx = await db.Database.BeginTransactionAsync();

        var producto = new Producto
        {
            NombreProducto = nombre,
            Descripcion = string.IsNullOrWhiteSpace(descripcion) ? null : descripcion.Trim(),
            IdCategoria = categoria,
            IdMarca = marca,
            Estado = true
        };
        db.Productos.Add(producto);
        await db.SaveChangesAsync();

        foreach (var x in variantes)
        {
            var variante = new ProductoVariante
            {
                IdProducto = producto.IdProducto,
                IdTalla = x.IdTalla,
                IdColor = x.IdColor,
                Codigo = $"TMP-{Guid.NewGuid():N}",
                StockActual = x.StockActual,
                StockMinimo = x.StockMinimo,
                PrecioCompra = x.PrecioCompra,
                PrecioVenta = x.PrecioVenta,
                Estado = true
            };
            db.ProductoVariantes.Add(variante);
            await db.SaveChangesAsync();
            variante.Codigo = $"NK-P{producto.IdProducto:D6}-V{variante.IdVariante:D6}";
            await db.SaveChangesAsync();
        }

        await tx.CommitAsync();
        return producto.IdProducto;
    }
}
