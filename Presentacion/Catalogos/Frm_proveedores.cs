using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;
using NK_COLLECTION.Negocios.Catalogos;

namespace NK_COLLECTION.Presentacion.Catalogos
{
    public partial class Frm_proveedores : Form
    {
        private readonly Proveedor_Service _servicio = new(DbConfiguracion.Options);
        private int _idEditar;

        public Frm_proveedores()
        {
            InitializeComponent();
            NK_COLLECTION.Presentacion.Estilos.EstiloNk.Preparar(this);

            Load += async (_, _) => await CargarAsync();

            btn_mostrar.Click += btn_mostrar_Click;
            btn_guardar.Click += btn_guardar_Click;
            btn_limpiar.Click += btn_limpiar_Click;
            btn_guardar_nuevo.Click += GuardarNuevo;
            btn_cancelar_nuevo.Click += (_, _) => LimpiarNuevo();
            btn_guardar_editar.Click += GuardarEditar;
            btn_cancelar_editar.Click += (_, _) => LimpiarEditar();

            dgw_proveedores.CellDoubleClick += Seleccionar;
            dgw_proveedores_editar.CellDoubleClick += Seleccionar;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private async void btn_buscar_Click(object sender, EventArgs e)
        {
            var proveedores = await _servicio.BuscarAsync(txtbox_buscarpor.Text);
            MostrarPrincipal(proveedores);
        }

        private async void btn_mostrar_Click(object sender, EventArgs e)
        {
            await CargarAsync();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabpag_nuevo_proveedor;
        }

        private async void btn_limpiar_Click(object sender, EventArgs e)
        {
            txtbox_buscarpor.Clear();
            await CargarAsync();
        }

        //guardar proveedor
        private async void GuardarNuevo(object? sender, EventArgs e)
        {
            try
            {
                await _servicio.GuardarAsync(
                    txtbox_nombre.Text,
                    txtbox_telefono.Text,
                    txtbox_correo_electronico.Text,
                    txtbox_direccion.Text,
                    txtbox_ruc.Text);

                MessageBox.Show("Proveedor guardado correctamente.");

                LimpiarNuevo();
                await CargarAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Proveedores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //seleccionar proveedor
        private async void Seleccionar(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || sender is not DataGridView grid)
                return;

            if (grid.Rows[e.RowIndex].Tag is not int id)
                return;

            var proveedor = await _servicio.ObtenerPorIdAsync(id);

            if (proveedor == null)
                return;

            _idEditar = proveedor.IdProveedor;

            txtbox_nombre_editar.Text = proveedor.Nombre;
            txtbox_telefono_editar.Text = proveedor.Telefono ?? string.Empty;
            txtbox_correo_electronico_editar.Text = proveedor.Correo ?? string.Empty;
            txtbox_direccion_editar.Text = proveedor.Direccion ?? string.Empty;
            txtbox_ruc_editar.Text = proveedor.Ruc ?? string.Empty;

            tabControl1.SelectedTab = tabPage3;
        }

        //editar proveedor
        private async void GuardarEditar(object? sender, EventArgs e)
        {
            try
            {
                if (_idEditar == 0)
                    throw new Exception("Seleccione un proveedor para editar.");

                await _servicio.EditarAsync(
                    _idEditar,
                    txtbox_nombre_editar.Text,
                    txtbox_telefono_editar.Text,
                    txtbox_correo_electronico_editar.Text,
                    txtbox_direccion_editar.Text,
                    txtbox_ruc_editar.Text);

                MessageBox.Show("Proveedor actualizado correctamente.");

                LimpiarEditar();
                await CargarAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Proveedores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task CargarAsync()
        {
            var proveedores = await _servicio.ListarAsync();

            MostrarPrincipal(proveedores);
            MostrarResumen(dgw_proveedores_nuevo, proveedores);
            MostrarResumen(dgw_proveedores_editar, proveedores);
        }

        private void MostrarPrincipal(List<Proveedor> proveedores)
        {
            dgw_proveedores.Rows.Clear();

            foreach (var proveedor in proveedores)
            {
                int fila = dgw_proveedores.Rows.Add(
                    proveedor.IdProveedor,
                    proveedor.Nombre,
                    proveedor.Telefono,
                    proveedor.Ruc,
                    proveedor.Direccion,
                    proveedor.Correo,
                    proveedor.Estado == true ? "Activo" : "Inactivo");

                dgw_proveedores.Rows[fila].Tag = proveedor.IdProveedor;
            }
        }

        private static void MostrarResumen(
            DataGridView grid,
            List<Proveedor> proveedores)
        {
            grid.Rows.Clear();

            foreach (var proveedor in proveedores)
            {
                int fila = grid.Rows.Add(
                    proveedor.Nombre,
                    proveedor.Direccion,
                    proveedor.Telefono,
                    proveedor.Estado == true ? "Activo" : "Inactivo");

                grid.Rows[fila].Tag = proveedor.IdProveedor;
            }
        }

        private void LimpiarNuevo()
        {
            txtbox_nombre.Clear();
            txtbox_telefono.Clear();
            txtbox_correo_electronico.Clear();
            txtbox_direccion.Clear();
            txtbox_ruc.Clear();
        }

        private void LimpiarEditar()
        {
            _idEditar = 0;

            txtbox_nombre_editar.Clear();
            txtbox_telefono_editar.Clear();
            txtbox_correo_electronico_editar.Clear();
            txtbox_direccion_editar.Clear();
            txtbox_ruc_editar.Clear();
        }
    }
}
