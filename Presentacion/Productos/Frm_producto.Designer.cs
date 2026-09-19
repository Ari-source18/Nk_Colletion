namespace NK_COLLECTION.Presentacion.Productos
{
    partial class Frm_producto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerResumen = new DataGridViewCellStyle();
            DataGridViewCellStyle rowResumen = new DataGridViewCellStyle();
            pnlEncabezado = new Guna.UI2.WinForms.Guna2Panel();
            btnVerTodos = new Guna.UI2.WinForms.Guna2Button();
            btnMarcas = new Guna.UI2.WinForms.Guna2Button();
            btnCategorias = new Guna.UI2.WinForms.Guna2Button();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlRegistro = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnGuardarProducto = new Guna.UI2.WinForms.Guna2Button();
            btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            pnlVariante = new Guna.UI2.WinForms.Guna2Panel();
            btnColores = new Guna.UI2.WinForms.Guna2Button();
            btnTallas = new Guna.UI2.WinForms.Guna2Button();
            btnAgregarVariante = new Guna.UI2.WinForms.Guna2Button();
            nudPrecioVenta = new NumericUpDown();
            nudPrecioCompra = new NumericUpDown();
            nudStockMinimo = new NumericUpDown();
            nudStock = new NumericUpDown();
            cmbColor = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbTalla = new Guna.UI2.WinForms.Guna2ComboBox();
            lblPrecioVenta = new Label();
            lblPrecioCompra = new Label();
            lblStockMinimo = new Label();
            lblStock = new Label();
            lblColor = new Label();
            lblTalla = new Label();
            lblVariante = new Label();
            cmbMarca = new Guna.UI2.WinForms.Guna2ComboBox();
            lblMarca = new Label();
            cmbCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            lblCategoria = new Label();
            txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            lblDescripcion = new Label();
            txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            lblNombre = new Label();
            lblRegistrarAyuda = new Label();
            lblRegistrar = new Label();
            pnlResumen = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnAgregarVariantesExistente = new Guna.UI2.WinForms.Guna2Button();
            txtBuscarResumen = new Guna.UI2.WinForms.Guna2TextBox();
            cmbOrdenResumen = new Guna.UI2.WinForms.Guna2ComboBox();
            lblOrdenResumen = new Label();
            lblResumenTotal = new Label();
            lblResumenAyuda = new Label();
            lblResumen = new Label();
            dgvResumen = new Guna.UI2.WinForms.Guna2DataGridView();
            colIdProducto = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colMarcaResumen = new DataGridViewTextBoxColumn();
            colCategoriaResumen = new DataGridViewTextBoxColumn();
            colVariantesResumen = new DataGridViewTextBoxColumn();
            colStockResumen = new DataGridViewTextBoxColumn();
            colPrecioResumen = new DataGridViewTextBoxColumn();
            colEstadoResumen = new DataGridViewTextBoxColumn();
            pnlEncabezado.SuspendLayout();
            pnlRegistro.SuspendLayout();
            pnlVariante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            pnlResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).BeginInit();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(248, 241, 242);
            pnlEncabezado.Controls.Add(btnVerTodos);
            pnlEncabezado.Controls.Add(btnColores);
            pnlEncabezado.Controls.Add(btnTallas);
            pnlEncabezado.Controls.Add(btnMarcas);
            pnlEncabezado.Controls.Add(btnCategorias);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1556, 105);
            // 
            // btnVerTodos
            // 
            btnVerTodos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerTodos.BorderRadius = 8;
            btnVerTodos.FillColor = Color.FromArgb(64, 0, 0);
            btnVerTodos.Font = new Font("Book Antiqua", 9F, FontStyle.Bold);
            btnVerTodos.ForeColor = Color.White;
            btnVerTodos.Location = new Point(1316, 34);
            btnVerTodos.Name = "btnVerTodos";
            btnVerTodos.Size = new Size(205, 45);
            btnVerTodos.Text = "Ver todos los productos";
            btnVerTodos.Click += btnVerTodos_Click;
            // 
            // btnMarcas
            // 
            btnMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMarcas.BorderRadius = 8;
            btnMarcas.FillColor = Color.FromArgb(98, 48, 56);
            btnMarcas.Font = new Font("Book Antiqua", 9F, FontStyle.Bold);
            btnMarcas.ForeColor = Color.White;
            btnMarcas.Location = new Point(887, 34);
            btnMarcas.Name = "btnMarcas";
            btnMarcas.Size = new Size(135, 45);
            btnMarcas.Text = "Nueva marca";
            btnMarcas.Click += btnMarcas_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCategorias.BorderRadius = 8;
            btnCategorias.FillColor = Color.FromArgb(98, 48, 56);
            btnCategorias.Font = new Font("Book Antiqua", 9F, FontStyle.Bold);
            btnCategorias.ForeColor = Color.White;
            btnCategorias.Location = new Point(729, 34);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(145, 45);
            btnCategorias.Text = "Nueva categoría";
            btnCategorias.Click += btnCategorias_Click;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Book Antiqua", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 83, 86);
            lblSubtitulo.Location = new Point(38, 65);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(535, 23);
            lblSubtitulo.Text = "Registra productos y consulta la vista general agrupada por ID.";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Book Antiqua", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(64, 0, 0);
            lblTitulo.Location = new Point(33, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(204, 47);
            lblTitulo.Text = "Productos";
            // 
            // pnlRegistro
            // 
            pnlRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlRegistro.BackColor = Color.Transparent;
            pnlRegistro.Controls.Add(btnGuardarProducto);
            pnlRegistro.Controls.Add(btnLimpiar);
            pnlRegistro.Controls.Add(pnlVariante);
            pnlRegistro.Controls.Add(cmbMarca);
            pnlRegistro.Controls.Add(lblMarca);
            pnlRegistro.Controls.Add(cmbCategoria);
            pnlRegistro.Controls.Add(lblCategoria);
            pnlRegistro.Controls.Add(txtDescripcion);
            pnlRegistro.Controls.Add(lblDescripcion);
            pnlRegistro.Controls.Add(txtNombre);
            pnlRegistro.Controls.Add(lblNombre);
            pnlRegistro.Controls.Add(lblRegistrarAyuda);
            pnlRegistro.Controls.Add(lblRegistrar);
            pnlRegistro.FillColor = Color.White;
            pnlRegistro.Location = new Point(28, 110);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Radius = 12;
            pnlRegistro.ShadowColor = Color.FromArgb(90, 64, 0, 0);
            pnlRegistro.ShadowDepth = 18;
            pnlRegistro.ShadowShift = 2;
            pnlRegistro.Size = new Size(1500, 355);
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardarProducto.BorderRadius = 8;
            btnGuardarProducto.FillColor = Color.FromArgb(64, 0, 0);
            btnGuardarProducto.Font = new Font("Book Antiqua", 9F, FontStyle.Bold);
            btnGuardarProducto.ForeColor = Color.White;
            btnGuardarProducto.Location = new Point(1274, 297);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(185, 42);
            btnGuardarProducto.Text = "Guardar producto";
            btnGuardarProducto.Click += btnGuardarProducto_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLimpiar.BorderRadius = 8;
            btnLimpiar.FillColor = Color.FromArgb(98, 48, 56);
            btnLimpiar.Font = new Font("Book Antiqua", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(1110, 297);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(145, 42);
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // pnlVariante
            // 
            pnlVariante.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlVariante.BorderColor = Color.FromArgb(230, 214, 217);
            pnlVariante.BorderRadius = 10;
            pnlVariante.BorderThickness = 1;
            pnlVariante.Controls.Add(btnAgregarVariante);
            pnlVariante.Controls.Add(nudPrecioVenta);
            pnlVariante.Controls.Add(nudPrecioCompra);
            pnlVariante.Controls.Add(nudStockMinimo);
            pnlVariante.Controls.Add(nudStock);
            pnlVariante.Controls.Add(cmbColor);
            pnlVariante.Controls.Add(cmbTalla);
            pnlVariante.Controls.Add(lblPrecioVenta);
            pnlVariante.Controls.Add(lblPrecioCompra);
            pnlVariante.Controls.Add(lblStockMinimo);
            pnlVariante.Controls.Add(lblStock);
            pnlVariante.Controls.Add(lblColor);
            pnlVariante.Controls.Add(lblTalla);
            pnlVariante.Controls.Add(lblVariante);
            pnlVariante.FillColor = Color.FromArgb(252, 248, 249);
            pnlVariante.Location = new Point(31, 164);
            pnlVariante.Name = "pnlVariante";
            pnlVariante.Size = new Size(1428, 122);
            // 
            // btnColores
            // 
            btnColores.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnColores.BorderRadius = 8;
            btnColores.FillColor = Color.FromArgb(98, 48, 56);
            btnColores.Font = new Font("Book Antiqua", 9F, FontStyle.Bold);
            btnColores.ForeColor = Color.White;
            btnColores.Location = new Point(1169, 34);
            btnColores.Name = "btnColores";
            btnColores.Size = new Size(132, 45);
            btnColores.Text = "Nuevo color";
            btnColores.Click += btnColores_Click;
            // 
            // btnTallas
            // 
            btnTallas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTallas.BorderRadius = 8;
            btnTallas.FillColor = Color.FromArgb(98, 48, 56);
            btnTallas.Font = new Font("Book Antiqua", 9F, FontStyle.Bold);
            btnTallas.ForeColor = Color.White;
            btnTallas.Location = new Point(1037, 34);
            btnTallas.Name = "btnTallas";
            btnTallas.Size = new Size(118, 45);
            btnTallas.Text = "Nueva talla";
            btnTallas.Click += btnTallas_Click;
            // 
            // btnAgregarVariante
            // 
            btnAgregarVariante.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarVariante.BorderRadius = 8;
            btnAgregarVariante.FillColor = Color.FromArgb(64, 0, 0);
            btnAgregarVariante.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold);
            btnAgregarVariante.ForeColor = Color.White;
            btnAgregarVariante.Location = new Point(1232, 60);
            btnAgregarVariante.Name = "btnAgregarVariante";
            btnAgregarVariante.Size = new Size(174, 43);
            btnAgregarVariante.Text = "+ Agregar variante";
            btnAgregarVariante.Visible = false;
            btnAgregarVariante.Click += btnAgregarVariante_Click;
            // 
            // nudPrecioVenta
            // 
            nudPrecioVenta.DecimalPlaces = 2;
            nudPrecioVenta.Font = new Font("Segoe UI", 9F);
            nudPrecioVenta.Location = new Point(1070, 66);
            nudPrecioVenta.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPrecioVenta.Name = "nudPrecioVenta";
            nudPrecioVenta.Size = new Size(142, 31);
            nudPrecioVenta.ThousandsSeparator = true;
            // 
            // nudPrecioCompra
            // 
            nudPrecioCompra.DecimalPlaces = 2;
            nudPrecioCompra.Font = new Font("Segoe UI", 9F);
            nudPrecioCompra.Location = new Point(904, 66);
            nudPrecioCompra.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPrecioCompra.Name = "nudPrecioCompra";
            nudPrecioCompra.Size = new Size(142, 31);
            nudPrecioCompra.ThousandsSeparator = true;
            // 
            // nudStockMinimo
            // 
            nudStockMinimo.Font = new Font("Segoe UI", 9F);
            nudStockMinimo.Location = new Point(766, 66);
            nudStockMinimo.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudStockMinimo.Name = "nudStockMinimo";
            nudStockMinimo.Size = new Size(116, 31);
            // 
            // nudStock
            // 
            nudStock.Font = new Font("Segoe UI", 9F);
            nudStock.Location = new Point(645, 66);
            nudStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(99, 31);
            // 
            // cmbColor
            // 
            cmbColor.BackColor = Color.Transparent;
            cmbColor.BorderColor = Color.FromArgb(216, 216, 216);
            cmbColor.BorderRadius = 8;
            cmbColor.DrawMode = DrawMode.OwnerDrawFixed;
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.FillColor = Color.White;
            cmbColor.Font = new Font("Segoe UI", 9F);
            cmbColor.ForeColor = Color.FromArgb(68, 68, 68);
            cmbColor.ItemHeight = 30;
            cmbColor.Location = new Point(316, 59);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(210, 36);
            // 
            // cmbTalla
            // 
            cmbTalla.BackColor = Color.Transparent;
            cmbTalla.BorderColor = Color.FromArgb(216, 216, 216);
            cmbTalla.BorderRadius = 8;
            cmbTalla.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTalla.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTalla.FillColor = Color.White;
            cmbTalla.Font = new Font("Segoe UI", 9F);
            cmbTalla.ForeColor = Color.FromArgb(68, 68, 68);
            cmbTalla.ItemHeight = 30;
            cmbTalla.Location = new Point(24, 59);
            cmbTalla.Name = "cmbTalla";
            cmbTalla.Size = new Size(270, 36);
            // 
            // labels variante
            // 
            lblPrecioVenta.AutoSize = true; lblPrecioVenta.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblPrecioVenta.ForeColor = Color.FromArgb(64, 0, 0); lblPrecioVenta.Location = new Point(1070, 41); lblPrecioVenta.Name = "lblPrecioVenta"; lblPrecioVenta.Text = "Precio venta";
            lblPrecioCompra.AutoSize = true; lblPrecioCompra.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblPrecioCompra.ForeColor = Color.FromArgb(64, 0, 0); lblPrecioCompra.Location = new Point(904, 41); lblPrecioCompra.Name = "lblPrecioCompra"; lblPrecioCompra.Text = "Precio compra";
            lblStockMinimo.AutoSize = true; lblStockMinimo.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblStockMinimo.ForeColor = Color.FromArgb(64, 0, 0); lblStockMinimo.Location = new Point(766, 41); lblStockMinimo.Name = "lblStockMinimo"; lblStockMinimo.Text = "Stock mínimo";
            lblStock.AutoSize = true; lblStock.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblStock.ForeColor = Color.FromArgb(64, 0, 0); lblStock.Location = new Point(645, 41); lblStock.Name = "lblStock"; lblStock.Text = "Stock";
            lblColor.AutoSize = true; lblColor.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblColor.ForeColor = Color.FromArgb(64, 0, 0); lblColor.Location = new Point(316, 35); lblColor.Name = "lblColor"; lblColor.Text = "Color";
            lblTalla.AutoSize = true; lblTalla.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblTalla.ForeColor = Color.FromArgb(64, 0, 0); lblTalla.Location = new Point(24, 35); lblTalla.Name = "lblTalla"; lblTalla.Text = "Talla";
            lblVariante.AutoSize = true; lblVariante.Font = new Font("Book Antiqua", 9.5F, FontStyle.Bold); lblVariante.ForeColor = Color.FromArgb(64, 0, 0); lblVariante.Location = new Point(20, 8); lblVariante.Name = "lblVariante"; lblVariante.Text = "Variante inicial del producto";
            // 
            // cmbMarca
            // 
            cmbMarca.BackColor = Color.Transparent;
            cmbMarca.BorderColor = Color.FromArgb(216, 216, 216);
            cmbMarca.BorderRadius = 8;
            cmbMarca.DrawMode = DrawMode.OwnerDrawFixed;
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FillColor = Color.FromArgb(248, 241, 242);
            cmbMarca.Font = new Font("Segoe UI", 9F);
            cmbMarca.ForeColor = Color.FromArgb(68, 68, 68);
            cmbMarca.ItemHeight = 30;
            cmbMarca.Location = new Point(1120, 110);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(339, 36);
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true; lblMarca.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold); lblMarca.ForeColor = Color.FromArgb(64, 0, 0); lblMarca.Location = new Point(1120, 85); lblMarca.Name = "lblMarca"; lblMarca.Text = "Marca";
            // 
            // cmbCategoria
            // 
            cmbCategoria.BackColor = Color.Transparent;
            cmbCategoria.BorderColor = Color.FromArgb(216, 216, 216);
            cmbCategoria.BorderRadius = 8;
            cmbCategoria.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FillColor = Color.FromArgb(248, 241, 242);
            cmbCategoria.Font = new Font("Segoe UI", 9F);
            cmbCategoria.ForeColor = Color.FromArgb(68, 68, 68);
            cmbCategoria.ItemHeight = 30;
            cmbCategoria.Location = new Point(780, 110);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(318, 36);
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true; lblCategoria.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold); lblCategoria.ForeColor = Color.FromArgb(64, 0, 0); lblCategoria.Location = new Point(780, 85); lblCategoria.Name = "lblCategoria"; lblCategoria.Text = "Categoría";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderColor = Color.FromArgb(216, 216, 216);
            txtDescripcion.BorderRadius = 8;
            txtDescripcion.DefaultText = "";
            txtDescripcion.FillColor = Color.FromArgb(248, 241, 242);
            txtDescripcion.Font = new Font("Segoe UI", 9F);
            txtDescripcion.Location = new Point(391, 110);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Descripción opcional";
            txtDescripcion.SelectedText = "";
            txtDescripcion.Size = new Size(367, 36);
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true; lblDescripcion.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold); lblDescripcion.ForeColor = Color.FromArgb(64, 0, 0); lblDescripcion.Location = new Point(391, 85); lblDescripcion.Name = "lblDescripcion"; lblDescripcion.Text = "Descripción";
            // 
            // txtNombre
            // 
            txtNombre.BorderColor = Color.FromArgb(216, 216, 216);
            txtNombre.BorderRadius = 8;
            txtNombre.DefaultText = "";
            txtNombre.FillColor = Color.FromArgb(248, 241, 242);
            txtNombre.Font = new Font("Segoe UI", 9F);
            txtNombre.Location = new Point(31, 110);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej. Camisa deportiva Nike";
            txtNombre.SelectedText = "";
            txtNombre.Size = new Size(338, 36);
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true; lblNombre.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold); lblNombre.ForeColor = Color.FromArgb(64, 0, 0); lblNombre.Location = new Point(31, 85); lblNombre.Name = "lblNombre"; lblNombre.Text = "Nombre del producto";
            // 
            // lblRegistrarAyuda
            // 
            lblRegistrarAyuda.AutoSize = true;
            lblRegistrarAyuda.Font = new Font("Book Antiqua", 8.5F);
            lblRegistrarAyuda.ForeColor = Color.Gray;
            lblRegistrarAyuda.Location = new Point(31, 49);
            lblRegistrarAyuda.Name = "lblRegistrarAyuda";
            lblRegistrarAyuda.Size = new Size(822, 21);
            lblRegistrarAyuda.Text = "Completa los datos del producto y define su primera combinación de talla y color.";
            // 
            // lblRegistrar
            // 
            lblRegistrar.AutoSize = true;
            lblRegistrar.Font = new Font("Book Antiqua", 12F, FontStyle.Bold);
            lblRegistrar.ForeColor = Color.FromArgb(64, 0, 0);
            lblRegistrar.Location = new Point(26, 17);
            lblRegistrar.Name = "lblRegistrar";
            lblRegistrar.Size = new Size(209, 28);
            lblRegistrar.Text = "Registrar producto";
            // 
            // pnlResumen
            // 
            pnlResumen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlResumen.BackColor = Color.Transparent;
            pnlResumen.Controls.Add(btnAgregarVariantesExistente);
            pnlResumen.Controls.Add(txtBuscarResumen);
            pnlResumen.Controls.Add(cmbOrdenResumen);
            pnlResumen.Controls.Add(lblOrdenResumen);
            pnlResumen.Controls.Add(lblResumenTotal);
            pnlResumen.Controls.Add(lblResumenAyuda);
            pnlResumen.Controls.Add(lblResumen);
            pnlResumen.Controls.Add(dgvResumen);
            pnlResumen.FillColor = Color.White;
            pnlResumen.Location = new Point(28, 478);
            pnlResumen.Name = "pnlResumen";
            pnlResumen.Radius = 12;
            pnlResumen.ShadowColor = Color.FromArgb(90, 64, 0, 0);
            pnlResumen.ShadowDepth = 18;
            pnlResumen.ShadowShift = 2;
            pnlResumen.Size = new Size(1500, 363);
            // 
            // btnAgregarVariantesExistente
            // 
            btnAgregarVariantesExistente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarVariantesExistente.BorderRadius = 8;
            btnAgregarVariantesExistente.Enabled = false;
            btnAgregarVariantesExistente.FillColor = Color.FromArgb(98, 48, 56);
            btnAgregarVariantesExistente.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold);
            btnAgregarVariantesExistente.ForeColor = Color.White;
            btnAgregarVariantesExistente.Location = new Point(700, 22);
            btnAgregarVariantesExistente.Name = "btnAgregarVariantesExistente";
            btnAgregarVariantesExistente.Size = new Size(212, 42);
            btnAgregarVariantesExistente.Text = "+ Agregar variantes";
            btnAgregarVariantesExistente.Click += btnAgregarVariantesExistente_Click;
            // 
            // txtBuscarResumen
            // 
            txtBuscarResumen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBuscarResumen.BorderColor = Color.FromArgb(216, 216, 216);
            txtBuscarResumen.BorderRadius = 8;
            txtBuscarResumen.DefaultText = "";
            txtBuscarResumen.FillColor = Color.FromArgb(248, 241, 242);
            txtBuscarResumen.Font = new Font("Segoe UI", 9F);
            txtBuscarResumen.Location = new Point(1110, 22);
            txtBuscarResumen.Name = "txtBuscarResumen";
            txtBuscarResumen.PlaceholderText = "Buscar producto...";
            txtBuscarResumen.SelectedText = "";
            txtBuscarResumen.Size = new Size(350, 42);
            txtBuscarResumen.TextChanged += txtBuscarResumen_TextChanged;
            // 
            // cmbOrdenResumen
            // 
            cmbOrdenResumen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbOrdenResumen.BackColor = Color.Transparent;
            cmbOrdenResumen.BorderColor = Color.FromArgb(216, 216, 216);
            cmbOrdenResumen.BorderRadius = 8;
            cmbOrdenResumen.DrawMode = DrawMode.OwnerDrawFixed;
            cmbOrdenResumen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrdenResumen.FillColor = Color.FromArgb(248, 241, 242);
            cmbOrdenResumen.Font = new Font("Segoe UI", 8.5F);
            cmbOrdenResumen.ForeColor = Color.FromArgb(68, 68, 68);
            cmbOrdenResumen.ItemHeight = 28;
            cmbOrdenResumen.Location = new Point(932, 29);
            cmbOrdenResumen.Name = "cmbOrdenResumen";
            cmbOrdenResumen.Size = new Size(160, 36);
            cmbOrdenResumen.SelectedIndexChanged += cmbOrdenResumen_SelectedIndexChanged;
            // 
            // lblOrdenResumen
            // 
            lblOrdenResumen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOrdenResumen.AutoSize = true;
            lblOrdenResumen.Font = new Font("Book Antiqua", 7.5F, FontStyle.Bold);
            lblOrdenResumen.ForeColor = Color.FromArgb(64, 0, 0);
            lblOrdenResumen.Location = new Point(932, 7);
            lblOrdenResumen.Name = "lblOrdenResumen";
            lblOrdenResumen.Text = "Orden";
            // 
            // lblResumenTotal
            // 
            lblResumenTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResumenTotal.AutoSize = true;
            lblResumenTotal.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold);
            lblResumenTotal.ForeColor = Color.FromArgb(98, 48, 56);
            lblResumenTotal.Location = new Point(31, 329);
            lblResumenTotal.Name = "lblResumenTotal";
            lblResumenTotal.Size = new Size(298, 20);
            lblResumenTotal.Text = "Mostrando 0 producto(s) agrupados por ID";
            // 
            // lblResumenAyuda
            // 
            lblResumenAyuda.AutoSize = true;
            lblResumenAyuda.Font = new Font("Book Antiqua", 8.5F);
            lblResumenAyuda.ForeColor = Color.Gray;
            lblResumenAyuda.Location = new Point(31, 50);
            lblResumenAyuda.Name = "lblResumenAyuda";
            lblResumenAyuda.Size = new Size(652, 21);
            lblResumenAyuda.Text = "Selecciona un producto y pulsa «Agregar variantes» para añadir nuevas tallas o colores.";
            // 
            // lblResumen
            // 
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Book Antiqua", 12F, FontStyle.Bold);
            lblResumen.ForeColor = Color.FromArgb(64, 0, 0);
            lblResumen.Location = new Point(26, 16);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(291, 28);
            lblResumen.Text = "Vista general de productos";
            // 
            // dgvResumen
            // 
            dgvResumen.AllowUserToAddRows = false;
            dgvResumen.AllowUserToDeleteRows = false;
            dgvResumen.AllowUserToResizeRows = false;
            dgvResumen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResumen.BackgroundColor = Color.White;
            dgvResumen.BorderStyle = BorderStyle.None;
            headerResumen.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerResumen.BackColor = Color.FromArgb(64, 0, 0);
            headerResumen.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold);
            headerResumen.ForeColor = Color.White;
            headerResumen.SelectionBackColor = Color.FromArgb(64, 0, 0);
            headerResumen.SelectionForeColor = Color.White;
            headerResumen.WrapMode = DataGridViewTriState.True;
            dgvResumen.ColumnHeadersDefaultCellStyle = headerResumen;
            dgvResumen.ColumnHeadersHeight = 40;
            dgvResumen.Columns.AddRange(new DataGridViewColumn[] { colIdProducto, colProducto, colMarcaResumen, colCategoriaResumen, colVariantesResumen, colStockResumen, colPrecioResumen, colEstadoResumen });
            rowResumen.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rowResumen.BackColor = Color.White;
            rowResumen.Font = new Font("Segoe UI", 8.5F);
            rowResumen.ForeColor = Color.FromArgb(45, 45, 45);
            rowResumen.SelectionBackColor = Color.FromArgb(241, 225, 228);
            rowResumen.SelectionForeColor = Color.FromArgb(64, 0, 0);
            dgvResumen.DefaultCellStyle = rowResumen;
            dgvResumen.EnableHeadersVisualStyles = false;
            dgvResumen.GridColor = Color.FromArgb(238, 228, 230);
            dgvResumen.Location = new Point(31, 82);
            dgvResumen.MultiSelect = false;
            dgvResumen.Name = "dgvResumen";
            dgvResumen.ReadOnly = true;
            dgvResumen.RowHeadersVisible = false;
            dgvResumen.RowTemplate.Height = 36;
            dgvResumen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResumen.Size = new Size(1429, 232);
            dgvResumen.SelectionChanged += dgvResumen_SelectionChanged;
            dgvResumen.CellDoubleClick += dgvResumen_CellDoubleClick;
            colIdProducto.HeaderText = "ID"; colIdProducto.Name = "colIdProducto"; colIdProducto.ReadOnly = true; colIdProducto.Width = 70;
            colProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; colProducto.FillWeight = 140F; colProducto.HeaderText = "Producto"; colProducto.Name = "colProducto"; colProducto.ReadOnly = true;
            colMarcaResumen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; colMarcaResumen.HeaderText = "Marca"; colMarcaResumen.Name = "colMarcaResumen"; colMarcaResumen.ReadOnly = true;
            colCategoriaResumen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; colCategoriaResumen.HeaderText = "Categoría"; colCategoriaResumen.Name = "colCategoriaResumen"; colCategoriaResumen.ReadOnly = true;
            colVariantesResumen.HeaderText = "Variantes"; colVariantesResumen.Name = "colVariantesResumen"; colVariantesResumen.ReadOnly = true; colVariantesResumen.Width = 105;
            colStockResumen.HeaderText = "Stock total"; colStockResumen.Name = "colStockResumen"; colStockResumen.ReadOnly = true; colStockResumen.Width = 100;
            colPrecioResumen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; colPrecioResumen.HeaderText = "Precio venta"; colPrecioResumen.Name = "colPrecioResumen"; colPrecioResumen.ReadOnly = true;
            colEstadoResumen.HeaderText = "Estado"; colEstadoResumen.Name = "colEstadoResumen"; colEstadoResumen.ReadOnly = true; colEstadoResumen.Width = 100;
            // 
            // Frm_producto
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 241, 242);
            ClientSize = new Size(1556, 867);
            Controls.Add(pnlResumen);
            Controls.Add(pnlRegistro);
            Controls.Add(pnlEncabezado);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_producto";
            Text = "Productos";
            Load += Frm_producto_Load;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlRegistro.ResumeLayout(false);
            pnlRegistro.PerformLayout();
            pnlVariante.ResumeLayout(false);
            pnlVariante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            pnlResumen.ResumeLayout(false);
            pnlResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlEncabezado;
        private Guna.UI2.WinForms.Guna2Button btnVerTodos;
        private Guna.UI2.WinForms.Guna2Button btnMarcas;
        private Guna.UI2.WinForms.Guna2Button btnCategorias;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlRegistro;
        private Guna.UI2.WinForms.Guna2Button btnGuardarProducto;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Guna.UI2.WinForms.Guna2Panel pnlVariante;
        private Guna.UI2.WinForms.Guna2Button btnColores;
        private Guna.UI2.WinForms.Guna2Button btnTallas;
        private Guna.UI2.WinForms.Guna2Button btnAgregarVariante;
        private NumericUpDown nudPrecioVenta;
        private NumericUpDown nudPrecioCompra;
        private NumericUpDown nudStockMinimo;
        private NumericUpDown nudStock;
        private Guna.UI2.WinForms.Guna2ComboBox cmbColor;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTalla;
        private Label lblPrecioVenta;
        private Label lblPrecioCompra;
        private Label lblStockMinimo;
        private Label lblStock;
        private Label lblColor;
        private Label lblTalla;
        private Label lblVariante;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMarca;
        private Label lblMarca;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategoria;
        private Label lblCategoria;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private Label lblDescripcion;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private Label lblNombre;
        private Label lblRegistrarAyuda;
        private Label lblRegistrar;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlResumen;
        private Guna.UI2.WinForms.Guna2Button btnAgregarVariantesExistente;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscarResumen;
        private Guna.UI2.WinForms.Guna2ComboBox cmbOrdenResumen;
        private Label lblOrdenResumen;
        private Label lblResumenTotal;
        private Label lblResumenAyuda;
        private Label lblResumen;
        private Guna.UI2.WinForms.Guna2DataGridView dgvResumen;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colMarcaResumen;
        private DataGridViewTextBoxColumn colCategoriaResumen;
        private DataGridViewTextBoxColumn colVariantesResumen;
        private DataGridViewTextBoxColumn colStockResumen;
        private DataGridViewTextBoxColumn colPrecioResumen;
        private DataGridViewTextBoxColumn colEstadoResumen;
    }
}
