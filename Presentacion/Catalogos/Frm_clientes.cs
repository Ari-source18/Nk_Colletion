using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;
using NK_COLLECTION.Negocios.Catalogos;

namespace NK_COLLECTION.Presentacion.Catalogos
{
    public partial class Frm_clientes : Form
    {
        private readonly Cliente_Service _servicio = new(DbConfiguracion.Options);
        private int _idEditar;

        public Frm_clientes()
        {
            InitializeComponent();
            NK_COLLECTION.Presentacion.Estilos.EstiloNk.Preparar(this);

            Load += Frm_clientes_Load;
            cmb_estado.SelectedIndex = 0;

            btn_guardar_cliente.Click += btn_guardar_cliente_Click;
            btn_limpiar_cliente.Click += (_, _) => LimpiarNuevo();
            btn_guardar_editar.Click += btn_guardar_editar_Click;
            btn_limpiar_editar.Click += (_, _) => LimpiarEditar();

            Dtgrdvw_cliente.CellDoubleClick += Grid_CellDoubleClick;
            dgw_cliente_editar.CellDoubleClick += Grid_CellDoubleClick;
        }

        private async void Frm_clientes_Load(object? sender, EventArgs e)
        {
            await CargarAsync();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private async void btn_buscar_Click(object sender, EventArgs e)
        {
            string texto = Microsoft.VisualBasic.Interaction.InputBox(
                "Escriba nombre, apellido, cédula, teléfono o correo:",
                "Buscar cliente");

            var clientes = await _servicio.BuscarAsync(texto);
            Mostrar(Dtgrdvw_cliente, clientes);
        }

        private async void btn_mostrartodo_Click(object sender, EventArgs e)
        {
            await CargarAsync();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabpag_nuevo_cliente;
        }

        private async void btn_limpiar_Click(object sender, EventArgs e)
        {
            await CargarAsync();
        }

        //guardar cliente
        private async void btn_guardar_cliente_Click(object? sender, EventArgs e)
        {
            try
            {
                var partes = txtbox_nombre.Text
                    .Trim()
                    .Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

                if (partes.Length < 2)
                    throw new Exception("Ingrese nombre y apellido del cliente.");

                await _servicio.GuardarAsync(
                    LimpiarTexto(txtbox_cedula.Text),
                    partes[0],
                    partes[1],
                    LimpiarTexto(txtbox_telefono.Text),
                    LimpiarTexto(txtbox_correo_electronico.Text),
                    LimpiarTexto(txtbox_direccion.Text));

                MessageBox.Show("Cliente guardado correctamente.");

                LimpiarNuevo();
                await CargarAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //seleccionar cliente
        private async void Grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || sender is not DataGridView grid)
                return;

            if (grid.Rows[e.RowIndex].Tag is not int id)
                return;

            var cliente = await _servicio.ObtenerPorIdAsync(id);

            if (cliente == null)
                return;

            _idEditar = cliente.IdCliente;

            txtbox_id_editar.Text = cliente.IdCliente.ToString();
            txtbox_nombre_editar.Text = $"{cliente.Nombre} {cliente.Apellido}".Trim();
            txtbox_cedula_editar.Text = cliente.Cedula ?? string.Empty;
            txtbox_telefono_editar.Text = cliente.Telefono ?? string.Empty;
            txtbox_correo_editar.Text = cliente.Correo ?? string.Empty;
            txtbox_direccion_editar.Text = cliente.Direccion ?? string.Empty;
            cmb_estado_editar.SelectedItem = cliente.Estado == true ? "Activo" : "Inactivo";

            tabControl1.SelectedTab = tabPage3;
        }

        //editar cliente
        private async void btn_guardar_editar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idEditar == 0)
                    throw new Exception("Seleccione un cliente para editar.");

                var partes = txtbox_nombre_editar.Text
                    .Trim()
                    .Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

                if (partes.Length < 2)
                    throw new Exception("Ingrese nombre y apellido.");

                await _servicio.EditarAsync(
                    _idEditar,
                    LimpiarTexto(txtbox_cedula_editar.Text),
                    partes[0],
                    partes[1],
                    LimpiarTexto(txtbox_telefono_editar.Text),
                    LimpiarTexto(txtbox_correo_editar.Text),
                    LimpiarTexto(txtbox_direccion_editar.Text));

                bool activo = cmb_estado_editar.SelectedItem?.ToString() != "Inactivo";
                await _servicio.CambiarEstadoAsync(_idEditar, activo);

                MessageBox.Show("Cliente actualizado correctamente.");

                LimpiarEditar();
                await CargarAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task CargarAsync()
        {
            var clientes = await _servicio.ListarAsync();

            Mostrar(Dtgrdvw_cliente, clientes);
            Mostrar(dgw_nuevo_cliente, clientes);
            Mostrar(dgw_cliente_editar, clientes);
        }

        private static void Mostrar(DataGridView grid, List<Cliente> clientes)
        {
            grid.Rows.Clear();

            foreach (var cliente in clientes)
            {
                int fila = grid.Rows.Add(
                    cliente.IdCliente,
                    $"{cliente.Nombre} {cliente.Apellido}".Trim(),
                    cliente.Telefono,
                    cliente.Cedula,
                    cliente.Direccion,
                    cliente.Correo,
                    cliente.Estado == true ? "Activo" : "Inactivo");

                grid.Rows[fila].Tag = cliente.IdCliente;
            }
        }

        private static string? LimpiarTexto(string texto)
        {
            texto = texto.Trim();

            if (string.IsNullOrWhiteSpace(texto))
                return null;

            if (texto.StartsWith("Ingrese ", StringComparison.OrdinalIgnoreCase))
                return null;

            return texto;
        }

        private void LimpiarNuevo()
        {
            txtbox_id.Clear();
            txtbox_nombre.Clear();
            txtbox_cedula.Clear();
            txtbox_telefono.Clear();
            txtbox_correo_electronico.Clear();
            txtbox_direccion.Clear();
            cmb_estado.SelectedIndex = 0;
        }

        private void LimpiarEditar()
        {
            _idEditar = 0;

            txtbox_id_editar.Clear();
            txtbox_nombre_editar.Clear();
            txtbox_cedula_editar.Clear();
            txtbox_telefono_editar.Clear();
            txtbox_correo_editar.Clear();
            txtbox_direccion_editar.Clear();
            cmb_estado_editar.SelectedIndex = -1;
        }
    }
}
