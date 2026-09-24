using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Negocios.Autenticacion;

namespace NK_COLLECTION
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var options =
                new DbContextOptionsBuilder<NkCollectionContext>()
                    .UseNpgsql(
                        "Host=localhost;" +
                        "Port=5432;" +
                        "Database=NK_COLLECTION;" +
                        "Username=Ari;" +
                        "Password=12345"
                    )
                    .Options;

            DbConfiguracion.Inicializar(options);

            var servicioAuth =
                new ServicioAuth(options);

            var loginServicio =
                new LoginServicio(options);

            var usuarioService =
                new NK_COLLECTION.Negocios.Catalogos.UsuarioService(options);
         

            Application.Run(
                new Frm_login(
                    servicioAuth,
                    loginServicio,
                    usuarioService
                )
            );
        }
    }
}