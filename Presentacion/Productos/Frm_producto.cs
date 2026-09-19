using Microsoft.VisualBasic;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Negocios.Catalogos;

namespace NK_COLLECTION.Presentacion.Productos
{
    public partial class Frm_producto : Form
    {
        private readonly Producto_Service _productos = new(DbConfiguracion.Options);
        private readonly Caregoria_Service _categorias = new(DbConfiguracion.Options);
        private readonly Marca_Service _marcas = new(DbConfiguracion.Options);
        private readonly Color_Service _colores = new(DbConfiguracion.Options);
        private readonly Talla_Service _tallas = new(DbConfiguracion.Options);
        private readonly List<VarianteNueva> _variantes = new();

        private readonly TextBox txtNombre = new() { Width = 260 };
        private readonly TextBox txtDescripcion = new() { Width = 260 };
        private readonly ComboBox cbCategoria = new() { Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cbMarca = new() { Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cbTalla = new() { Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cbColor = new() { Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly NumericUpDown nudStock = new() { Maximum = 100000, Width = 120 };
        private readonly NumericUpDown nudStockMin = new() { Maximum = 100000, Width = 120 };
        private readonly NumericUpDown nudCompra = new() { Maximum = 10000000, DecimalPlaces = 2, Width = 140 };
        private readonly NumericUpDown nudVenta = new() { Maximum = 10000000, DecimalPlaces = 2, Width = 140 };
        private readonly DataGridView dgvVariantes = new() { Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

        public Frm_producto()
        {
            InitializeComponent();
            Load += Frm_producto_Load;
        }

        private async void Frm_producto_Load(object? sender, EventArgs e)
        {
            // La pantalla anterior con TabControl ya no se usa.
            guna2ShadowPanel1.Visible = false;
            CrearPantallaConvencional();
            await CargarCatalogos();
        }

        private void CrearPantallaConvencional()
        {
            var contenedor = new Panel { Left = 25, Top = 130, Width = ClientSize.Width - 50, Height = ClientSize.Height - 155, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right, AutoScroll = true };
            Controls.Add(contenedor);
            contenedor.BringToFront();

            var titulo = new Label { Text = "Registrar producto", AutoSize = true, Font = new Font("Segoe UI", 18, FontStyle.Bold), Left = 15, Top = 5 };
            contenedor.Controls.Add(titulo);

            int y = 55;
            AgregarCampo(contenedor, "Nombre del producto", txtNombre, 20, y);
            AgregarCampo(contenedor, "Descripción", txtDescripcion, 410, y);
            y += 70;
            AgregarCampo(contenedor, "Categoría", cbCategoria, 20, y);
            var btnCategoria = BotonNuevo("+ Nueva categoría", 260, y + 24); btnCategoria.Click += async (_, _) => await NuevaCategoria(); contenedor.Controls.Add(btnCategoria);
            AgregarCampo(contenedor, "Marca", cbMarca, 410, y);
            var btnMarca = BotonNuevo("+ Nueva marca", 650, y + 24); btnMarca.Click += async (_, _) => await NuevaMarca(); contenedor.Controls.Add(btnMarca);

            y += 85;
            var separador = new Label { Text = "Agregar variante", AutoSize = true, Font = new Font("Segoe UI", 13, FontStyle.Bold), Left = 20, Top = y };
            contenedor.Controls.Add(separador); y += 35;
            AgregarCampo(contenedor, "Talla", cbTalla, 20, y);
            var btnTalla = BotonNuevo("+ Nueva talla", 215, y + 24); btnTalla.Click += async (_, _) => await NuevaTalla(); contenedor.Controls.Add(btnTalla);
            AgregarCampo(contenedor, "Color", cbColor, 355, y);
            var btnColor = BotonNuevo("+ Nuevo color", 550, y + 24); btnColor.Click += async (_, _) => await NuevoColor(); contenedor.Controls.Add(btnColor);
            AgregarCampo(contenedor, "Stock", nudStock, 690, y);
            AgregarCampo(contenedor, "Stock mínimo", nudStockMin, 830, y);
            AgregarCampo(contenedor, "Precio compra", nudCompra, 970, y);
            AgregarCampo(contenedor, "Precio venta", nudVenta, 1130, y);

            var btnAgregar = new Button { Text = "Agregar variante", Left = 1290, Top = y + 23, Width = 145, Height = 32 };
            btnAgregar.Click += (_, _) => AgregarVariante(); contenedor.Controls.Add(btnAgregar);

            dgvVariantes.Top = y + 80; dgvVariantes.Left = 20; dgvVariantes.Width = contenedor.Width - 40; dgvVariantes.Height = 250;
            dgvVariantes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvVariantes.Columns.Add("Talla", "Talla"); dgvVariantes.Columns.Add("Color", "Color"); dgvVariantes.Columns.Add("Stock", "Stock"); dgvVariantes.Columns.Add("Min", "Stock mínimo"); dgvVariantes.Columns.Add("Compra", "Precio compra"); dgvVariantes.Columns.Add("Venta", "Precio venta");
            contenedor.Controls.Add(dgvVariantes);

            var btnQuitar = new Button { Text = "Quitar variante", Left = 20, Top = y + 340, Width = 145, Height = 38 };
            btnQuitar.Click += (_, _) => QuitarVariante(); contenedor.Controls.Add(btnQuitar);
            var btnGuardar = new Button { Text = "Guardar producto", Left = 180, Top = y + 340, Width = 160, Height = 38 };
            btnGuardar.Click += async (_, _) => await GuardarProducto(); contenedor.Controls.Add(btnGuardar);
            var btnLimpiar = new Button { Text = "Limpiar", Left = 355, Top = y + 340, Width = 120, Height = 38 };
            btnLimpiar.Click += (_, _) => Limpiar(); contenedor.Controls.Add(btnLimpiar);
        }

        private static void AgregarCampo(Control padre, string etiqueta, Control control, int x, int y)
        {
            padre.Controls.Add(new Label { Text = etiqueta, AutoSize = true, Left = x, Top = y });
            control.Left = x; control.Top = y + 24; padre.Controls.Add(control);
        }
        private static Button BotonNuevo(string texto, int x, int y) => new() { Text = texto, Left = x, Top = y, Width = 135, Height = 30 };

        private async Task CargarCatalogos()
        {
            CargarCombo(cbCategoria, await _categorias.ListarAsync(), "NombreCategoria", "IdCategoria");
            CargarCombo(cbMarca, await _marcas.ListarAsync(), "Nombre", "IdMarca");
            CargarCombo(cbColor, await _colores.ListarAsync(), "NombreColor", "IdColor");
            CargarCombo(cbTalla, await _tallas.ListarAsync(), "NombreTalla", "IdTalla");
        }
        private static void CargarCombo(ComboBox c, object data, string display, string value) { c.DataSource = null; c.DataSource = data; c.DisplayMember = display; c.ValueMember = value; c.SelectedIndex = -1; }
        private static int? Id(ComboBox c) => c.SelectedValue == null ? null : Convert.ToInt32(c.SelectedValue);

        private void AgregarVariante()
        {
            if (cbTalla.SelectedIndex < 0 || cbColor.SelectedIndex < 0) { MessageBox.Show("Seleccione talla y color."); return; }
            var nueva = new VarianteNueva(Id(cbTalla), Id(cbColor), (int)nudStock.Value, (int)nudStockMin.Value, nudCompra.Value, nudVenta.Value);
            if (_variantes.Any(v => v.IdTalla == nueva.IdTalla && v.IdColor == nueva.IdColor)) { MessageBox.Show("Esa combinación de talla y color ya fue agregada."); return; }
            _variantes.Add(nueva);
            dgvVariantes.Rows.Add(cbTalla.Text, cbColor.Text, nueva.StockActual, nueva.StockMinimo, nueva.PrecioCompra, nueva.PrecioVenta);
        }
        private void QuitarVariante()
        {
            if (dgvVariantes.CurrentRow == null) return;
            int i = dgvVariantes.CurrentRow.Index; if (i < 0 || i >= _variantes.Count) return;
            _variantes.RemoveAt(i); dgvVariantes.Rows.RemoveAt(i);
        }
        private async Task GuardarProducto()
        {
            try
            {
                int id = await _productos.GuardarProductoConVariantesAsync(txtNombre.Text, txtDescripcion.Text, Id(cbCategoria), Id(cbMarca), _variantes);
                MessageBox.Show($"Producto guardado correctamente. ID producto: {id}\nCada variante recibió su ID y código automáticamente.");
                Limpiar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Limpiar()
        {
            txtNombre.Clear(); txtDescripcion.Clear(); cbCategoria.SelectedIndex = -1; cbMarca.SelectedIndex = -1; cbTalla.SelectedIndex = -1; cbColor.SelectedIndex = -1;
            nudStock.Value = nudStockMin.Value = 0; nudCompra.Value = nudVenta.Value = 0; _variantes.Clear(); dgvVariantes.Rows.Clear();
        }

        private async Task NuevaCategoria() { var n = Interaction.InputBox("Nombre de la categoría:", "Nueva categoría"); if (string.IsNullOrWhiteSpace(n)) return; try { await _categorias.GuardarAsync(n, null); await CargarCatalogos(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private async Task NuevaMarca() { var n = Interaction.InputBox("Nombre de la marca:", "Nueva marca"); if (string.IsNullOrWhiteSpace(n)) return; try { await _marcas.GuardarAsync(n); await CargarCatalogos(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private async Task NuevaTalla() { var n = Interaction.InputBox("Nombre de la talla:", "Nueva talla"); if (string.IsNullOrWhiteSpace(n)) return; try { await _tallas.GuardarAsync(n); await CargarCatalogos(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
        private async Task NuevoColor() { var n = Interaction.InputBox("Nombre del color:", "Nuevo color"); if (string.IsNullOrWhiteSpace(n)) return; try { await _colores.GuardarAsync(n); await CargarCatalogos(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
    }
}
