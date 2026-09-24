using Guna.UI2.WinForms;
using NK_COLLECTION.Negocios.Autenticacion;

namespace NK_COLLECTION.Presentacion.Autenticacion
{
    public partial class Frm_recuperacion : Form
    {
        private readonly LoginServicio _loginServicio;

        private string _correo = "";
        private string _codigo = "";

        private PasoRecuperacion _paso = PasoRecuperacion.Correo;

        private readonly Guna2TextBox txtCodigo = new();
        private readonly Guna2TextBox txtNuevaContrasena = new();
        private readonly Guna2TextBox txtConfirmarContrasena = new();

        private enum PasoRecuperacion
        {
            Correo,
            Codigo,
            NuevaContrasena
        }

        public Frm_recuperacion(LoginServicio loginServicio)
        {
            InitializeComponent();

            _loginServicio = loginServicio;

            CrearControles();

            btn_ingresar.Click += btn_ingresar_Click;
            linklbl_volver.LinkClicked += linklbl_volver_LinkClicked;
        }

        private void Frm_recuperacion_Load(object sender, EventArgs e)
        {
            txtbox_correo_electronico.Clear();
            txtbox_correo_electronico.PlaceholderText = "Correo electrónico";

            label5.Text = "Ingrese su correo y le enviaremos un código de recuperación.";
            btn_ingresar.Text = "Enviar código";

            txtbox_correo_electronico.Focus();
        }

        private void CrearControles()
        {
            ConfigurarTextBox(txtCodigo, "Código de 6 dígitos");
            ConfigurarTextBox(txtNuevaContrasena, "Nueva contraseña");
            ConfigurarTextBox(txtConfirmarContrasena, "Confirmar contraseña");

            txtCodigo.MaxLength = 6;

            txtNuevaContrasena.UseSystemPasswordChar = true;
            txtConfirmarContrasena.UseSystemPasswordChar = true;

            txtCodigo.Visible = false;
            txtNuevaContrasena.Visible = false;
            txtConfirmarContrasena.Visible = false;

            Controls.Add(txtCodigo);
            Controls.Add(txtNuevaContrasena);
            Controls.Add(txtConfirmarContrasena);
        }

        private static void ConfigurarTextBox(
            Guna2TextBox textBox,
            string placeholder)
        {
            textBox.Size = new Size(511, 45);
            textBox.FillColor = Color.FromArgb(248, 241, 242);
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.PlaceholderText = placeholder;
            textBox.TextOffset = new Point(10, 0);
        }

        private async void btn_ingresar_Click(object? sender, EventArgs e)
        {
            try
            {
                btn_ingresar.Enabled = false;

                switch (_paso)
                {
                    case PasoRecuperacion.Correo:
                        await EnviarCodigo();
                        break;

                    case PasoRecuperacion.Codigo:
                        await ValidarCodigo();
                        break;

                    case PasoRecuperacion.NuevaContrasena:
                        await CambiarContrasena();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Recuperación de contraseña",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btn_ingresar.Enabled = true;
            }
        }

        private async Task EnviarCodigo()
        {
            string correo = txtbox_correo_electronico.Text.Trim();

            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show(
                    "Ingrese su correo electrónico.",
                    "Recuperación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            btn_ingresar.Text = "Enviando...";

            bool enviado = await _loginServicio
                .EnviarCodigoRecuperacionAsync(correo);

            if (!enviado)
            {
                btn_ingresar.Text = "Enviar código";

                MessageBox.Show(
                    "No existe un usuario activo con ese correo.",
                    "Recuperación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            _correo = correo;

            MessageBox.Show(
                "Código enviado correctamente.",
                "Recuperación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            MostrarCodigo();
        }

        private void MostrarCodigo()
        {
            _paso = PasoRecuperacion.Codigo;

            txtbox_correo_electronico.Visible = false;

            txtCodigo.Visible = true;
            txtCodigo.Location = txtbox_correo_electronico.Location;
            txtCodigo.BringToFront();

            label5.Text = "Ingrese el código de 6 dígitos enviado a su correo.";
            btn_ingresar.Text = "Verificar código";

            txtCodigo.Focus();
        }

        private async Task ValidarCodigo()
        {
            string codigo = txtCodigo.Text.Trim();

            if (codigo.Length != 6 || !codigo.All(char.IsDigit))
            {
                MessageBox.Show(
                    "El código debe contener 6 números.",
                    "Código inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            btn_ingresar.Text = "Verificando...";

            bool valido = await _loginServicio.ValidarCodigoAsync(
                _correo,
                codigo
            );

            if (!valido)
            {
                btn_ingresar.Text = "Verificar código";

                MessageBox.Show(
                    "El código es incorrecto o ha expirado.",
                    "Código inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            _codigo = codigo;

            MostrarNuevaContrasena();
        }

        private void MostrarNuevaContrasena()
        {
            _paso = PasoRecuperacion.NuevaContrasena;

            txtCodigo.Visible = false;

            txtNuevaContrasena.Visible = true;
            txtConfirmarContrasena.Visible = true;

            txtNuevaContrasena.Location = new Point(
                txtbox_correo_electronico.Left,
                txtbox_correo_electronico.Top - 20
            );

            txtConfirmarContrasena.Location = new Point(
                txtbox_correo_electronico.Left,
                txtbox_correo_electronico.Top + 40
            );

            txtNuevaContrasena.BringToFront();
            txtConfirmarContrasena.BringToFront();

            label5.Text = "Ingrese y confirme su nueva contraseña.";
            btn_ingresar.Text = "Restablecer contraseña";

            txtNuevaContrasena.Focus();
        }

        private async Task CambiarContrasena()
        {
            string nueva = txtNuevaContrasena.Text;
            string confirmar = txtConfirmarContrasena.Text;

            if (string.IsNullOrWhiteSpace(nueva))
            {
                MessageBox.Show(
                    "Ingrese una nueva contraseña.",
                    "Recuperación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (nueva.Length < 6)
            {
                MessageBox.Show(
                    "La contraseña debe tener al menos 6 caracteres.",
                    "Recuperación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (nueva != confirmar)
            {
                MessageBox.Show(
                    "Las contraseñas no coinciden.",
                    "Recuperación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            btn_ingresar.Text = "Guardando...";

            bool cambiado = await _loginServicio.CambiarContrasenaAsync(
                _correo,
                _codigo,
                nueva
            );

            if (!cambiado)
            {
                btn_ingresar.Text = "Restablecer contraseña";

                MessageBox.Show(
                    "El código ya no es válido o ha expirado.",
                    "Recuperación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                "Contraseña cambiada correctamente.",
                "NK Collection",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Close();
        }

        private void linklbl_volver_LinkClicked(
            object? sender,
            LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void linklbl_volver_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}