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
            Load += Frm_clientes_Load;
            cmb_estado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmb_estado_editar.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmb_estado.SelectedIndex = 0;
            btn_guardar_cliente.Click += btn_guardar_cliente_Click;
            btn_limpiar_cliente.Click += (_, _) => LimpiarNuevo();
            btn_guardar_editar.Click += btn_guardar_editar_Click;
            btn_limpiar_editar.Click += (_, _) => LimpiarEditar();
            Dtgrdvw_cliente.CellDoubleClick += Grid_CellDoubleClick;
            dgw_cliente_editar.CellDoubleClick += Grid_CellDoubleClick;
        }

        private async void Frm_clientes_Load(object? sender, EventArgs e) => await CargarAsync();
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }

        private async void btn_buscar_Click(object sender, EventArgs e)
        {
            var texto = Microsoft.VisualBasic.Interaction.InputBox("Escriba nombre, apellido, cédula, teléfono o correo:", "Buscar cliente");
            Mostrar(Dtgrdvw_cliente, await _servicio.BuscarAsync(texto));
        }
        private async void btn_mostrartodo_Click(object sender, EventArgs e) => await CargarAsync();
        private void btn_guardar_Click(object sender, EventArgs e) => tabControl1.SelectedTab = tabpag_nuevo_cliente;
        private async void btn_limpiar_Click(object sender, EventArgs e) => await CargarAsync();

        private async void btn_guardar_cliente_Click(object? sender, EventArgs e)
        {
            try
            {
                var partes = txtbox_nombre.Text.Trim().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length < 2) throw new Exception("Ingrese nombre y apellido del cliente.");
                await _servicio.GuardarAsync(LimpiarTexto(txtbox_cedula.Text), partes[0], partes[1], LimpiarTexto(txtbox_telefono.Text), LimpiarTexto(txtbox_correo_electronico.Text), LimpiarTexto(txtbox_direccion.Text));
                MessageBox.Show("Cliente guardado correctamente."); LimpiarNuevo(); await CargarAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void Grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || sender is not DataGridView g || g.Rows[e.RowIndex].Tag is not int id) return;
            var c = await _servicio.ObtenerPorIdAsync(id); if (c == null) return;
            _idEditar = c.IdCliente; txtbox_id_editar.Text = c.IdCliente.ToString(); txtbox_nombre_editar.Text = $"{c.Nombre} {c.Apellido}".Trim();
            txtbox_cedula_editar.Text = c.Cedula ?? ""; txtbox_telefono_editar.Text = c.Telefono ?? ""; txtbox_correo_editar.Text = c.Correo ?? ""; txtbox_direccion_editar.Text = c.Direccion ?? "";
            cmb_estado_editar.SelectedItem = c.Estado == true ? "Activo" : "Inactivo"; tabControl1.SelectedTab = tabPage3;
        }

        private async void btn_guardar_editar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idEditar == 0) throw new Exception("Seleccione un cliente para editar.");
                var partes = txtbox_nombre_editar.Text.Trim().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries); if (partes.Length < 2) throw new Exception("Ingrese nombre y apellido.");
                await _servicio.EditarAsync(_idEditar, LimpiarTexto(txtbox_cedula_editar.Text), partes[0], partes[1], LimpiarTexto(txtbox_telefono_editar.Text), LimpiarTexto(txtbox_correo_editar.Text), LimpiarTexto(txtbox_direccion_editar.Text));
                await _servicio.CambiarEstadoAsync(_idEditar, cmb_estado_editar.SelectedItem?.ToString() != "Inactivo");
                MessageBox.Show("Cliente actualizado correctamente."); LimpiarEditar(); await CargarAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async Task CargarAsync() { var x = await _servicio.ListarAsync(); Mostrar(Dtgrdvw_cliente,x); Mostrar(dgw_nuevo_cliente,x); Mostrar(dgw_cliente_editar,x); }
        private static void Mostrar(DataGridView g, List<Cliente> xs) { g.Rows.Clear(); foreach(var c in xs){ int i=g.Rows.Add(c.IdCliente,$"{c.Nombre} {c.Apellido}".Trim(),c.Telefono,c.Cedula,c.Direccion,c.Correo,c.Estado==true?"Activo":"Inactivo"); g.Rows[i].Tag=c.IdCliente; } }
        private static string? LimpiarTexto(string s) { s=s.Trim(); return string.IsNullOrWhiteSpace(s)||s.StartsWith("Ingrese ",StringComparison.OrdinalIgnoreCase)?null:s; }
        private void LimpiarNuevo(){ txtbox_id.Clear(); txtbox_nombre.Clear(); txtbox_cedula.Clear(); txtbox_telefono.Clear(); txtbox_correo_electronico.Clear(); txtbox_direccion.Clear(); cmb_estado.SelectedIndex=0; }
        private void LimpiarEditar(){ _idEditar=0; txtbox_id_editar.Clear(); txtbox_nombre_editar.Clear(); txtbox_cedula_editar.Clear(); txtbox_telefono_editar.Clear(); txtbox_correo_editar.Clear(); txtbox_direccion_editar.Clear(); cmb_estado_editar.SelectedIndex=-1; }
    }
}
