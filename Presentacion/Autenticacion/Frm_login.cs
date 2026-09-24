using NK_COLLECTION.Negocios.Autenticacion;
using NK_COLLECTION.Presentacion.Autenticacion;
using NK_COLLECTION.Presentacion.Principal;
using NK_COLLECTION.Negocios.Catalogos;
using NK_COLLECTION.Presentacion.Caja;

namespace NK_COLLECTION
{
    public partial class Frm_login : Form
    {
        private readonly ServicioAuth _servicioAuth;
        private readonly LoginServicio _loginServicio;
        private readonly UsuarioService _usuarioService;

        public Frm_login(
            ServicioAuth servicioAuth,
            LoginServicio loginServicio,
            UsuarioService usuarioService)
        {
            InitializeComponent();

            _servicioAuth = servicioAuth;
            _loginServicio = loginServicio;
            _usuarioService = usuarioService;

            linklbl_contrasena.LinkClicked += linklbl_contrasena_LinkClicked;
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            txtbox_usuario.Clear();
            txtbox_contrasena.Clear();

            txtbox_usuario.PlaceholderText = "Usuario";
            txtbox_contrasena.PlaceholderText = "Contraseña";

            txtbox_contrasena.UseSystemPasswordChar = true;

            txtbox_usuario.Focus();
        }

        private async void btn_ingresar_Click(object sender, EventArgs e)
        {
            string usuario = txtbox_usuario.Text.Trim();
            string contrasena = txtbox_contrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show(
                    "Ingrese su usuario.",
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtbox_usuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show(
                    "Ingrese su contraseña.",
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtbox_contrasena.Focus();
                return;
            }

            try
            {
                btn_ingresar.Enabled = false;
                btn_ingresar.Text = "Ingresando...";

                var usuarioSesion = await _servicioAuth.ValidarCredencialesAsync(
                    usuario,
                    contrasena
                );

                if (usuarioSesion == null)
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos, o la cuenta está inactiva.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtbox_contrasena.Clear();
                    txtbox_contrasena.Focus();

                    return;
                }

                MessageBox.Show(
                    $"Bienvenido, {usuarioSesion.NombreCompleto}.",
                    "NK Collection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                var principal = new Frm_apertura ();

                principal.FormClosed += (_, _) => Close();

                Hide();
                principal.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al iniciar sesión.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btn_ingresar.Enabled = true;
                btn_ingresar.Text = "Ingresar";
            }
        }

        private void linklbl_contrasena_LinkClicked(
            object? sender,
            LinkLabelLinkClickedEventArgs e)
        {
            var recuperacion = new Frm_recuperacion(_loginServicio);

            recuperacion.ShowDialog(this);
        }
    }
}