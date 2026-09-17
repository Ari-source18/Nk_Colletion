using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Negocios.Seguridad;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace NK_COLLECTION.Negocios.Autenticacion
{
    public class LoginServicio
    {
        private readonly DbContextOptions<NkCollectionContext> _options;

        // CONFIGURACIÓN DEL CORREO
        private const string CorreoRemitente = "nk_collection@zohomail.com";
        private const string ContrasenaCorreo = "MG4ihpbHWj7H";
        private const string ServidorSmtp = "smtp.zoho.com";
        private const int PuertoSmtp = 587;

        public LoginServicio(DbContextOptions<NkCollectionContext> options)
        {
            _options = options;
        }

        // ENVIAR CÓDIGO DE RECUPERACIÓN
     
        public async Task<bool> EnviarCodigoRecuperacionAsync(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            correo = correo.Trim().ToLower();

            if (!MailAddress.TryCreate(correo, out _))
                throw new ArgumentException("El correo electrónico no es válido.");

            await using var contexto = new NkCollectionContext(_options);

            var usuario = await contexto.Usuarios.FirstOrDefaultAsync(u =>
                u.Correo != null &&
                EF.Functions.ILike(u.Correo, correo) &&
                u.Estado
            );

            if (usuario == null)
                return false;

            string codigo = RandomNumberGenerator
                .GetInt32(100000, 1000000)
                .ToString();

            usuario.TokenRecuperacion = CrearHashCodigo(codigo);
            usuario.FechaHoraRecuperacion = DateTime.Now.AddMinutes(15);

            await contexto.SaveChangesAsync();

            try
            {
                await EnviarCorreoAsync(
                    usuario.Correo!,
                    usuario.Nombre,
                    codigo
                );

                return true;
            }
            catch
            {
                usuario.TokenRecuperacion = null;
                usuario.FechaHoraRecuperacion = null;

                await contexto.SaveChangesAsync();

                throw;
            }
        }

     
        // VALIDAR CÓDIGO
    
        public async Task<bool> ValidarCodigoAsync(string correo, string codigo)
        {
            if (string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(codigo))
                return false;

            correo = correo.Trim().ToLower();
            codigo = codigo.Trim();

            await using var contexto = new NkCollectionContext(_options);

            var usuario = await contexto.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u =>
                    u.Correo != null &&
                    EF.Functions.ILike(u.Correo, correo) &&
                    u.Estado
                );

            if (usuario == null ||
                string.IsNullOrWhiteSpace(usuario.TokenRecuperacion) ||
                !usuario.FechaHoraRecuperacion.HasValue)
                return false;

            if (usuario.FechaHoraRecuperacion.Value <= DateTime.Now)
                return false;

            return VerificarCodigo(
                codigo,
                usuario.TokenRecuperacion
            );
        }

        // CAMBIAR CONTRASEÑA
    
        public async Task<bool> CambiarContrasenaAsync(
            string correo,
            string codigo,
            string nuevaContrasena)
        {
            if (string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(codigo) ||
                string.IsNullOrWhiteSpace(nuevaContrasena))
                return false;

            if (nuevaContrasena.Length < 6)
                throw new ArgumentException(
                    "La contraseña debe tener al menos 6 caracteres."
                );

            correo = correo.Trim().ToLower();
            codigo = codigo.Trim();

            await using var contexto = new NkCollectionContext(_options);

            var usuario = await contexto.Usuarios.FirstOrDefaultAsync(u =>
                u.Correo != null &&
                EF.Functions.ILike(u.Correo, correo) &&
                u.Estado
            );

            if (usuario == null ||
                string.IsNullOrWhiteSpace(usuario.TokenRecuperacion) ||
                !usuario.FechaHoraRecuperacion.HasValue)
                return false;

            // Código expirado
            if (usuario.FechaHoraRecuperacion.Value <= DateTime.Now)
            {
                usuario.TokenRecuperacion = null;
                usuario.FechaHoraRecuperacion = null;

                await contexto.SaveChangesAsync();

                return false;
            }

            // Código incorrecto
            if (!VerificarCodigo(codigo, usuario.TokenRecuperacion))
                return false;

            // Guardar nueva contraseña
            usuario.Contrasena = ContrasenaHelper.CrearHash(nuevaContrasena);

            // Invalidar código usado
            usuario.TokenRecuperacion = null;
            usuario.FechaHoraRecuperacion = null;

            await contexto.SaveChangesAsync();

            return true;
        }

        // CREAR HASH DEL CÓDIGO
    
        private static string CrearHashCodigo(string codigo)
        {
            byte[] datos = Encoding.UTF8.GetBytes(codigo);
            byte[] hash = SHA256.HashData(datos);

            return Convert.ToHexString(hash);
        }

   
        // VERIFICAR CÓDIGO
      
        private static bool VerificarCodigo(string codigo, string hashGuardado)
        {
            try
            {
                byte[] codigoHash = SHA256.HashData(
                    Encoding.UTF8.GetBytes(codigo)
                );

                byte[] hashEsperado = Convert.FromHexString(hashGuardado);

                return CryptographicOperations.FixedTimeEquals(
                    codigoHash,
                    hashEsperado
                );
            }
            catch
            {
                return false;
            }
        }

       
        // ENVIAR CORREO
    
        private static async Task EnviarCorreoAsync(
            string correoDestino,
            string nombre,
            string codigo)
        {
            try
            {
                using var smtp = new SmtpClient(ServidorSmtp, PuertoSmtp)
                {
                    Credentials = new NetworkCredential(
                        CorreoRemitente,
                        ContrasenaCorreo
                    ),
                    EnableSsl = true
                };

                using var mensaje = new MailMessage
                {
                    From = new MailAddress(
                        CorreoRemitente,
                        "NK Collection"
                    ),

                    Subject = "NK Collection - Recuperación de contraseña",
                    IsBodyHtml = true,

                    Body = $@"
<html>
<body style='font-family:Arial,sans-serif;background:#f5f5f5;padding:30px;'>

<div style='max-width:600px;margin:auto;background:white;padding:35px;border-radius:12px;'>
    
<img src='https://i.imgur.com/bxkZ0uD.png'
     alt='NK Collection'
     width='120'
     style='display:block;margin:0 auto;width:120px;height:auto;'>

    <h1 style='color:#400000;text-align:center;'>
        NK Collection
    </h1>

    <h2 style='color:#400000;'>
        Recuperación de contraseña
    </h2>

    <p>
        Hola <b>{WebUtility.HtmlEncode(nombre)}</b>,
    </p>

    <p>
        Recibimos una solicitud para restablecer tu contraseña.
    </p>

    <p>Tu código de recuperación es:</p>

    <div style='
        text-align:center;
        background:#f8f1f2;
        padding:20px;
        margin:25px 0;
        border-radius:10px;
        font-size:32px;
        font-weight:bold;
        letter-spacing:8px;
        color:#400000;
    '>
        {codigo}
    </div>

    <p>
        Este código será válido durante <b>15 minutos</b>.
    </p>

    <p style='color:#777;'>
        Si no solicitaste este cambio, puedes ignorar este mensaje.
    </p>

    <br>

    <p>
        Saludos,<br>
        <b>Equipo NK Collection</b>
    </p>

</div>

</body>
</html>"
                };

                mensaje.To.Add(correoDestino);

                await smtp.SendMailAsync(mensaje);
            }
            catch (SmtpException ex)
            {
                throw new Exception(
                    "No se pudo enviar el correo de recuperación. " +
                    ex.Message
                );
            }
        }
    }
}