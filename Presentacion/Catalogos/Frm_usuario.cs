using Guna.UI2.WinForms;
using NK_COLLECTION.Datos.Modelos;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Negocios.Catalogos;

namespace NK_COLLECTION.Presentacion.Catalogos
{
   
    public partial class Frm_usuario : Form
    {
        private readonly UsuarioService _usuarioServicio;

        private List<Rol> _roles = new();

        private int _idUsuarioEditar = 0;
        private bool _estadoActualEditar = true;

        public Frm_usuario() : this(new UsuarioService(DbConfiguracion.Options))
        {
        }

        public Frm_usuario(UsuarioService usuarioServicio)
        {
            InitializeComponent();

            _usuarioServicio = usuarioServicio;

            // Usuarios (lista / búsqueda)
            btn_mostrar.Click += btn_mostrar_Click;
            btn_buscar.Click += btn_buscar_Click;
            btn_limpiar_usuario.Click += btn_limpiar_usuario_Click;
            btn_guardar_usuario.Click += btn_guardar_usuario_Click;
            dgw_usuarios.CellDoubleClick += dgw_usuarios_CellDoubleClick;

            // Nuevo Usuario
            btn_guardar.Click += btn_guardar_Click;
            btn_limpiar.Click += btn_limpiar_Click;

            // Pestaña "Rol" (editar)
            btn_guardar_editar.Click += btn_guardar_editar_Click;
            btn_cancelar_editar.Click += btn_cancelar_editar_Click;
            dgw_usuario_editar.CellDoubleClick += dgw_usuario_editar_CellDoubleClick;
        }


        private async void Frm_usuario_Load(object sender, EventArgs e)
        {
            await CargarRolesAsync();
            await CargarTodoAsync();

            PrepararComboBuscarPor();
            LimpiarFormularioNuevo();
            LimpiarFormularioEditar();
        }

        private async void tabPage1_Click(object? sender, EventArgs e)
        {
            // Al entrar Usuarios se refresca la lista.
            await CargarTodoAsync();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private async Task CargarRolesAsync()
        {
            try
            {
                _roles = await _usuarioServicio.ListarRolesAsync();

                CargarComboRol(cmb_rol);
                CargarComboRol(txtbox_rol_editar);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudieron cargar los roles.", ex);
            }
        }

        private void CargarComboRol(Guna2ComboBox combo)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            combo.DataSource = _roles;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdRol";
            combo.SelectedIndex = -1;
        }

        private void PrepararComboBuscarPor()
        {
            CBbuscarpor.Items.Clear();
            CBbuscarpor.Items.Add("Todos");

            foreach (Rol rol in _roles)
            {
                CBbuscarpor.Items.Add(rol.Nombre);
            }

            CBbuscarpor.SelectedIndex = 0;
        }

        private async Task CargarTodoAsync()
        {
            try
            {
                List<Usuario> usuarios = await _usuarioServicio.ListarAsync();

                MostrarEnGrid(dgw_usuarios, usuarios);
                MostrarEnGrid(dgw_usuario_nuevo, usuarios);
                MostrarEnGrid(dgw_usuario_editar, usuarios);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudieron cargar los usuarios.", ex);
            }
        }

        private static void MostrarEnGrid(Guna2DataGridView grid, List<Usuario> usuarios)
        {
            grid.Rows.Clear();

            foreach (Usuario u in usuarios)
            {
                int fila = grid.Rows.Add(
                    $"{u.Nombre} {u.Apellido}".Trim(),
                    u.Correo,
                    u.Cedula,
                    u.Usuario1,
                    u.IdRolNavigation?.Nombre,
                    u.Estado ? "Activo" : "Inactivo"
                );

                grid.Rows[fila].Tag = u.IdUsuario;
            }
        }

        // USUARIOS (lista / búsqueda)

        private async void btn_mostrar_Click(object? sender, EventArgs e)
        {
            CBbuscarpor.SelectedIndex = 0;
            await CargarTodoAsync();
        }

        private async void btn_buscar_Click(object? sender, EventArgs e)
        {
            try
            {
                string criterio = CBbuscarpor.SelectedItem?.ToString() ?? "Todos";

                List<Usuario> usuarios = criterio == "Todos"
                    ? await _usuarioServicio.ListarAsync()
                    : await _usuarioServicio.BuscarAsync(criterio);

                MostrarEnGrid(dgw_usuarios, usuarios);
            }
            catch (Exception ex)
            {
                MostrarError("Error al buscar usuarios.", ex);
            }
        }

        private async void btn_limpiar_usuario_Click(object? sender, EventArgs e)
        {
            CBbuscarpor.SelectedIndex = 0;
            await CargarTodoAsync();
        }

        private async void btn_guardar_usuario_Click(object? sender, EventArgs e)
        {
            await CargarTodoAsync();
        }

        private async void dgw_usuarios_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgw_usuarios.Rows[e.RowIndex].Tag is not int idUsuario)
                return;

            try
            {
                Usuario? usuario = await _usuarioServicio.ObtenerPorIdAsync(idUsuario);

                if (usuario == null)
                    return;

                CargarUsuarioEnFormularioEditar(usuario);
                tabControl1.SelectedTab = tabpag_usuario_editar;
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cargar el usuario seleccionado.", ex);
            }
        }

        // NUEVO USUARIO

        private async void btn_guardar_Click(object? sender, EventArgs e)
        {
            try
            {
                btn_guardar.Enabled = false;

                if (cmb_rol.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Seleccione un rol.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                int idRol = Convert.ToInt32(cmb_rol.SelectedValue);

                string nombre = txt_nombre.Text.Trim();
                string apellido = txt_Apellido.Text.Trim();

                string cedula = txt_cedula.Text.Trim();
                string nombreUsuario = txt_usuario.Text.Trim();
                string contrasena = txt_contrasena.Text;
                string? correo = string.IsNullOrWhiteSpace(txt_correo.Text)
                    ? null
                    : txt_correo.Text.Trim();

                await _usuarioServicio.GuardarAsync(
                    idRol,
                    cedula,
                    nombre,
                    apellido,
                    nombreUsuario,
                    contrasena,
                    correo
                );

                MessageBox.Show(
                    "Usuario creado correctamente.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarFormularioNuevo();
                await CargarTodoAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btn_guardar.Enabled = true;
            }
        }

        private void btn_limpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormularioNuevo();
        }

        private void LimpiarFormularioNuevo()
        {
            txt_nombre.Clear();
            txt_Apellido.Clear();
            txt_correo.Clear();
            txt_cedula.Clear();
            txt_usuario.Clear();
            txt_contrasena.Clear();

            cmb_rol.SelectedIndex = -1;
            cmb_estado.SelectedIndex = -1;
        }

        
        // ROL (editar usuario)

        private async void dgw_usuario_editar_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgw_usuario_editar.Rows[e.RowIndex].Tag is not int idUsuario)
                return;

            try
            {
                Usuario? usuario = await _usuarioServicio.ObtenerPorIdAsync(idUsuario);

                if (usuario == null)
                    return;

                CargarUsuarioEnFormularioEditar(usuario);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cargar el usuario seleccionado.", ex);
            }
        }

        private void CargarUsuarioEnFormularioEditar(Usuario usuario)
        {
            _idUsuarioEditar = usuario.IdUsuario;
            _estadoActualEditar = usuario.Estado;

            txtbox_usuario_editar.Text = usuario.Nombre;
            txt_apellido_editar.Text = usuario.Apellido;
            txtbox_correo_editar.Text = usuario.Correo;
            txtbox_cedula_editar.Text = usuario.Cedula;
            txtbox_editar.Text = usuario.Usuario1;

            txtbox_contrasena_editar.Text = "";
            txtbox_contrasena_editar.PlaceholderText = "Dejar en blanco para no cambiarla";

            txtbox_rol_editar.SelectedValue = usuario.IdRol;
            txtbox_estado_editar.SelectedItem = usuario.Estado ? "Activo" : "Inactivo";
        }

        private async void btn_guardar_editar_Click(object? sender, EventArgs e)
        {
            if (_idUsuarioEditar == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la lista para editar.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                btn_guardar_editar.Enabled = false;

                if (txtbox_rol_editar.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Seleccione un rol.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                int idRol = Convert.ToInt32(txtbox_rol_editar.SelectedValue);

                string nombre = txtbox_usuario_editar.Text.Trim();
                string apellido = txt_apellido_editar.Text.Trim();

                string cedula = txtbox_cedula_editar.Text.Trim();
                string nombreUsuario = txtbox_editar.Text.Trim();
                string contrasena = txtbox_contrasena_editar.Text;
                string? correo = string.IsNullOrWhiteSpace(txtbox_correo_editar.Text)
                    ? null
                    : txtbox_correo_editar.Text.Trim();

                await _usuarioServicio.EditarAsync(
                    _idUsuarioEditar,
                    idRol,
                    cedula,
                    nombre,
                    apellido,
                    nombreUsuario,
                    correo,
                    string.IsNullOrWhiteSpace(contrasena) ? null : contrasena
                );

                bool nuevoEstado = txtbox_estado_editar.SelectedItem?.ToString() == "Activo";

                if (nuevoEstado != _estadoActualEditar)
                {
                    await _usuarioServicio.CambiarEstadoAsync(_idUsuarioEditar, nuevoEstado);
                }

                MessageBox.Show(
                    "Usuario actualizado correctamente.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarFormularioEditar();
                await CargarTodoAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btn_guardar_editar.Enabled = true;
            }
        }

        private void btn_cancelar_editar_Click(object? sender, EventArgs e)
        {
            LimpiarFormularioEditar();
        }

        private void LimpiarFormularioEditar()
        {
            _idUsuarioEditar = 0;
            _estadoActualEditar = true;

            txtbox_usuario_editar.Clear();
            txt_apellido_editar.Clear();
            txtbox_correo_editar.Clear();
            txtbox_cedula_editar.Clear();
            txtbox_editar.Clear();

            txtbox_contrasena_editar.Clear();
            txtbox_contrasena_editar.PlaceholderText = "Ingrese contraseña";

            txtbox_rol_editar.SelectedIndex = -1;
            txtbox_estado_editar.SelectedIndex = -1;
        }

        private static void MostrarError(string mensaje, Exception ex)
        {
            MessageBox.Show(
                $"{mensaje}\n\n{ex.Message}",
                "Usuarios",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}