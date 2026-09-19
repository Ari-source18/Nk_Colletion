using Microsoft.EntityFrameworkCore;

namespace NK_COLLECTION.Datos;

public static class DbConfiguracion
{
    public static DbContextOptions<NkCollectionContext> Options { get; private set; } = null!;

    public static void Inicializar(DbContextOptions<NkCollectionContext> options)
    {
        Options = options ?? throw new ArgumentNullException(nameof(options));
    }
}
