using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Negocios.Seguridad;

namespace NK_COLLECTION.Negocios.Autenticacion
{
    public class ServicioAuth
    {
        private readonly DbContextOptions<NkCollectionContext> _options;

        public ServicioAuth(DbContextOptions<NkCollectionContext> options)
        {
            _options = options;
        }

        public async Task<UsuarioSesion?> ValidarCredencialesAsync(
            string nombreUsuario,
            string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(contrasena))
                return null;

            await using var contexto = new NkCollectionContext(_options);

            var usuario = await contexto.Usuarios
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(u =>
                    EF.Functions.ILike(
                        u.Usuario1,
                        nombreUsuario.Trim()
                    )
                );

            if (usuario == null || !usuario.Estado)
                return null;

            bool contrasenaCorrecta;

            if (ContrasenaHelper.EsHashPbkdf2(usuario.Contrasena))
            {
                contrasenaCorrecta = ContrasenaHelper.Verificar(
                    contrasena,
                    usuario.Contrasena
                );
            }
            else
            {
                contrasenaCorrecta = usuario.Contrasena == contrasena;

                if (contrasenaCorrecta)
                {
                    usuario.Contrasena = ContrasenaHelper.CrearHash(contrasena);
                    await contexto.SaveChangesAsync();
                }
            }

            if (!contrasenaCorrecta)
                return null;

            return new UsuarioSesion
            {
                IdUsuario = usuario.IdUsuario,
                IdRol = usuario.IdRol,
                NombreCompleto = $"{usuario.Nombre} {usuario.Apellido}".Trim(),
                NombreUsuario = usuario.Usuario1,
                Correo = usuario.Correo ?? "",
                Rol = usuario.IdRolNavigation?.Nombre ?? "Sin rol"
            };
        }
    }

    public class UsuarioSesion
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public string NombreCompleto { get; set; } = "";
        public string NombreUsuario { get; set; } = "";
        public string Correo { get; set; } = "";
        public string Rol { get; set; } = "";
    }
}