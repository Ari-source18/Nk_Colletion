namespace NK_COLLECTION.Presentacion.Productos
{
    partial class Frm_producto_listado
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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            pnlEncabezado = new Guna.UI2.WinForms.Guna2Panel();
            btnVolver = new Guna.UI2.WinForms.Guna2Button();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlContenido = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            lblOrden = new Label();
            lblEstado = new Label();
            lblColor = new Label();
            lblTalla = new Label();
            lblMarca = new Label();
            lblCategoria = new Label();
            lblBuscar = new Label();
            cmbOrden = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbColor = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbTalla = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbMarca = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            lblResultados = new Label();
            lblInventarioAyuda = new Label();
            lblInventario = new Label();
            dgvProductos = new Guna.UI2.WinForms.Guna2DataGridView();
            colIdProducto = new DataGridViewTextBoxColumn();
            colIdVariante = new DataGridViewTextBoxColumn();
            colCodigo = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colMarca = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colTalla = new DataGridViewTextBoxColumn();
            colColor = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colStockMinimo = new DataGridViewTextBoxColumn();
            colPrecioCompra = new DataGridViewTextBoxColumn();
            colPrecioVenta = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            pnlEncabezado.SuspendLayout();
            pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(248, 241, 242);
            pnlEncabezado.Controls.Add(btnVolver);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1556, 112);
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVolver.BorderColor = Color.FromArgb(190, 160, 165);
            btnVolver.BorderRadius = 8;
            btnVolver.BorderThickness = 1;
            btnVolver.FillColor = Color.White;
            btnVolver.Font = new Font("Book Antiqua", 9F, FontStyle.Bold);
            btnVolver.ForeColor = Color.FromArgb(64, 0, 0);
            btnVolver.Location = new Point(1328, 34);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(190, 45);
            btnVolver.Text = "Volver a productos";
            btnVolver.Click += btnVolver_Click;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Book Antiqua", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 83, 86);
            lblSubtitulo.Location = new Point(38, 69);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(571, 23);
            lblSubtitulo.Text = "Inventario desglosado: una fila representa una variante del producto.";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Book Antiqua", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(64, 0, 0);
            lblTitulo.Location = new Point(33, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(512, 47);
            lblTitulo.Text = "Listado completo de productos";
            // 
            // pnlContenido
            // 
            pnlContenido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContenido.BackColor = Color.Transparent;
            pnlContenido.Controls.Add(btnLimpiar);
            pnlContenido.Controls.Add(lblOrden);
            pnlContenido.Controls.Add(lblEstado);
            pnlContenido.Controls.Add(lblColor);
            pnlContenido.Controls.Add(lblTalla);
            pnlContenido.Controls.Add(lblMarca);
            pnlContenido.Controls.Add(lblCategoria);
            pnlContenido.Controls.Add(lblBuscar);
            pnlContenido.Controls.Add(cmbOrden);
            pnlContenido.Controls.Add(cmbEstado);
            pnlContenido.Controls.Add(cmbColor);
            pnlContenido.Controls.Add(cmbTalla);
            pnlContenido.Controls.Add(cmbMarca);
            pnlContenido.Controls.Add(cmbCategoria);
            pnlContenido.Controls.Add(txtBuscar);
            pnlContenido.Controls.Add(lblResultados);
            pnlContenido.Controls.Add(lblInventarioAyuda);
            pnlContenido.Controls.Add(lblInventario);
            pnlContenido.Controls.Add(dgvProductos);
            pnlContenido.FillColor = Color.White;
            pnlContenido.Location = new Point(28, 120);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Radius = 12;
            pnlContenido.ShadowColor = Color.FromArgb(90, 64, 0, 0);
            pnlContenido.ShadowDepth = 18;
            pnlContenido.ShadowShift = 2;
            pnlContenido.Size = new Size(1500, 720);
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiar.BorderColor = Color.FromArgb(190, 160, 165);
            btnLimpiar.BorderRadius = 8;
            btnLimpiar.BorderThickness = 1;
            btnLimpiar.FillColor = Color.White;
            btnLimpiar.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.FromArgb(64, 0, 0);
            btnLimpiar.Location = new Point(1336, 111);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(124, 40);
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // etiquetas filtros
            // 
            lblBuscar.AutoSize = true; lblBuscar.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblBuscar.ForeColor = Color.FromArgb(64, 0, 0); lblBuscar.Location = new Point(31, 86); lblBuscar.Name = "lblBuscar"; lblBuscar.Text = "Buscar";
            lblCategoria.AutoSize = true; lblCategoria.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblCategoria.ForeColor = Color.FromArgb(64, 0, 0); lblCategoria.Location = new Point(327, 86); lblCategoria.Name = "lblCategoria"; lblCategoria.Text = "Categoría";
            lblMarca.AutoSize = true; lblMarca.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblMarca.ForeColor = Color.FromArgb(64, 0, 0); lblMarca.Location = new Point(497, 86); lblMarca.Name = "lblMarca"; lblMarca.Text = "Marca";
            lblTalla.AutoSize = true; lblTalla.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblTalla.ForeColor = Color.FromArgb(64, 0, 0); lblTalla.Location = new Point(667, 86); lblTalla.Name = "lblTalla"; lblTalla.Text = "Talla";
            lblColor.AutoSize = true; lblColor.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblColor.ForeColor = Color.FromArgb(64, 0, 0); lblColor.Location = new Point(812, 86); lblColor.Name = "lblColor"; lblColor.Text = "Color";
            lblEstado.AutoSize = true; lblEstado.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblEstado.ForeColor = Color.FromArgb(64, 0, 0); lblEstado.Location = new Point(957, 86); lblEstado.Name = "lblEstado"; lblEstado.Text = "Estado";
            lblOrden.AutoSize = true; lblOrden.Font = new Font("Book Antiqua", 8F, FontStyle.Bold); lblOrden.ForeColor = Color.FromArgb(64, 0, 0); lblOrden.Location = new Point(1092, 86); lblOrden.Name = "lblOrden"; lblOrden.Text = "Orden";
            // 
            // txtBuscar
            // 
            txtBuscar.BorderColor = Color.FromArgb(216, 216, 216);
            txtBuscar.BorderRadius = 8;
            txtBuscar.DefaultText = "";
            txtBuscar.FillColor = Color.FromArgb(248, 241, 242);
            txtBuscar.Font = new Font("Segoe UI", 9F);
            txtBuscar.Location = new Point(31, 111);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Producto, código, marca, categoría, talla o color";
            txtBuscar.SelectedText = "";
            txtBuscar.Size = new Size(280, 40);
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // cmbCategoria
            // 
            cmbCategoria.BackColor = Color.Transparent;
            cmbCategoria.BorderColor = Color.FromArgb(216, 216, 216);
            cmbCategoria.BorderRadius = 8;
            cmbCategoria.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FillColor = Color.FromArgb(248, 241, 242);
            cmbCategoria.Font = new Font("Segoe UI", 8.5F);
            cmbCategoria.ForeColor = Color.FromArgb(68, 68, 68);
            cmbCategoria.ItemHeight = 28;
            cmbCategoria.Location = new Point(327, 111);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(155, 34);
            cmbCategoria.SelectedIndexChanged += filtro_SelectedIndexChanged;
            // 
            // cmbMarca
            // 
            cmbMarca.BackColor = Color.Transparent;
            cmbMarca.BorderColor = Color.FromArgb(216, 216, 216);
            cmbMarca.BorderRadius = 8;
            cmbMarca.DrawMode = DrawMode.OwnerDrawFixed;
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FillColor = Color.FromArgb(248, 241, 242);
            cmbMarca.Font = new Font("Segoe UI", 8.5F);
            cmbMarca.ForeColor = Color.FromArgb(68, 68, 68);
            cmbMarca.ItemHeight = 28;
            cmbMarca.Location = new Point(497, 111);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(155, 34);
            cmbMarca.SelectedIndexChanged += filtro_SelectedIndexChanged;
            // 
            // cmbTalla
            // 
            cmbTalla.BackColor = Color.Transparent;
            cmbTalla.BorderColor = Color.FromArgb(216, 216, 216);
            cmbTalla.BorderRadius = 8;
            cmbTalla.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTalla.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTalla.FillColor = Color.FromArgb(248, 241, 242);
            cmbTalla.Font = new Font("Segoe UI", 8.5F);
            cmbTalla.ForeColor = Color.FromArgb(68, 68, 68);
            cmbTalla.ItemHeight = 28;
            cmbTalla.Location = new Point(667, 111);
            cmbTalla.Name = "cmbTalla";
            cmbTalla.Size = new Size(130, 34);
            cmbTalla.SelectedIndexChanged += filtro_SelectedIndexChanged;
            // 
            // cmbColor
            // 
            cmbColor.BackColor = Color.Transparent;
            cmbColor.BorderColor = Color.FromArgb(216, 216, 216);
            cmbColor.BorderRadius = 8;
            cmbColor.DrawMode = DrawMode.OwnerDrawFixed;
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.FillColor = Color.FromArgb(248, 241, 242);
            cmbColor.Font = new Font("Segoe UI", 8.5F);
            cmbColor.ForeColor = Color.FromArgb(68, 68, 68);
            cmbColor.ItemHeight = 28;
            cmbColor.Location = new Point(812, 111);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(130, 34);
            cmbColor.SelectedIndexChanged += filtro_SelectedIndexChanged;
            // 
            // cmbEstado
            // 
            cmbEstado.BackColor = Color.Transparent;
            cmbEstado.BorderColor = Color.FromArgb(216, 216, 216);
            cmbEstado.BorderRadius = 8;
            cmbEstado.DrawMode = DrawMode.OwnerDrawFixed;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FillColor = Color.FromArgb(248, 241, 242);
            cmbEstado.Font = new Font("Segoe UI", 8.5F);
            cmbEstado.ForeColor = Color.FromArgb(68, 68, 68);
            cmbEstado.ItemHeight = 28;
            cmbEstado.Location = new Point(957, 111);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(120, 34);
            cmbEstado.SelectedIndexChanged += filtro_SelectedIndexChanged;
            // 
            // cmbOrden
            // 
            cmbOrden.BackColor = Color.Transparent;
            cmbOrden.BorderColor = Color.FromArgb(216, 216, 216);
            cmbOrden.BorderRadius = 8;
            cmbOrden.DrawMode = DrawMode.OwnerDrawFixed;
            cmbOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrden.FillColor = Color.FromArgb(248, 241, 242);
            cmbOrden.Font = new Font("Segoe UI", 8.5F);
            cmbOrden.ForeColor = Color.FromArgb(68, 68, 68);
            cmbOrden.ItemHeight = 28;
            cmbOrden.Location = new Point(1092, 111);
            cmbOrden.Name = "cmbOrden";
            cmbOrden.Size = new Size(130, 34);
            cmbOrden.SelectedIndexChanged += cmbOrden_SelectedIndexChanged;
            // 
            // lblResultados
            // 
            lblResultados.AutoSize = true;
            lblResultados.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold);
            lblResultados.ForeColor = Color.FromArgb(98, 48, 56);
            lblResultados.Location = new Point(31, 166);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(177, 20);
            lblResultados.Text = "0 variantes encontradas";
            // 
            // lblInventarioAyuda
            // 
            lblInventarioAyuda.AutoSize = true;
            lblInventarioAyuda.Font = new Font("Book Antiqua", 8.5F);
            lblInventarioAyuda.ForeColor = Color.Gray;
            lblInventarioAyuda.Location = new Point(31, 53);
            lblInventarioAyuda.Name = "lblInventarioAyuda";
            lblInventarioAyuda.Size = new Size(947, 21);
            lblInventarioAyuda.Text = "Los filtros se aplican automáticamente al escribir o seleccionar una opción. Cada fila muestra una variante distinta.";
            // 
            // lblInventario
            // 
            lblInventario.AutoSize = true;
            lblInventario.Font = new Font("Book Antiqua", 13F, FontStyle.Bold);
            lblInventario.ForeColor = Color.FromArgb(64, 0, 0);
            lblInventario.Location = new Point(28, 21);
            lblInventario.Name = "lblInventario";
            lblInventario.Size = new Size(250, 30);
            lblInventario.Text = "Inventario detallado";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.ColumnHeadersDefaultCellStyle = headerStyle;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(64, 0, 0);
            headerStyle.Font = new Font("Book Antiqua", 8F, FontStyle.Bold);
            headerStyle.ForeColor = Color.White;
            headerStyle.SelectionBackColor = Color.FromArgb(64, 0, 0);
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersHeight = 44;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colIdProducto, colIdVariante, colCodigo, colProducto, colMarca, colCategoria, colTalla, colColor, colStock, colStockMinimo, colPrecioCompra, colPrecioVenta, colEstado });
            rowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = Color.White;
            rowStyle.Font = new Font("Segoe UI", 8.4F);
            rowStyle.ForeColor = Color.FromArgb(45, 45, 45);
            rowStyle.SelectionBackColor = Color.FromArgb(241, 225, 228);
            rowStyle.SelectionForeColor = Color.FromArgb(64, 0, 0);
            dgvProductos.DefaultCellStyle = rowStyle;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(238, 228, 230);
            dgvProductos.Location = new Point(31, 197);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowTemplate.Height = 38;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(1429, 493);
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            // columnas
            colIdProducto.HeaderText = "ID producto"; colIdProducto.Name = "colIdProducto"; colIdProducto.ReadOnly = true; colIdProducto.Width = 85;
            colIdVariante.HeaderText = "ID variante"; colIdVariante.Name = "colIdVariante"; colIdVariante.ReadOnly = true; colIdVariante.Width = 85;
            colCodigo.HeaderText = "Código"; colCodigo.Name = "colCodigo"; colCodigo.ReadOnly = true; colCodigo.Width = 170;
            colProducto.HeaderText = "Producto"; colProducto.Name = "colProducto"; colProducto.ReadOnly = true; colProducto.Width = 190;
            colMarca.HeaderText = "Marca"; colMarca.Name = "colMarca"; colMarca.ReadOnly = true; colMarca.Width = 130;
            colCategoria.HeaderText = "Categoría"; colCategoria.Name = "colCategoria"; colCategoria.ReadOnly = true; colCategoria.Width = 150;
            colTalla.HeaderText = "Talla"; colTalla.Name = "colTalla"; colTalla.ReadOnly = true; colTalla.Width = 90;
            colColor.HeaderText = "Color"; colColor.Name = "colColor"; colColor.ReadOnly = true; colColor.Width = 110;
            colStock.HeaderText = "Stock"; colStock.Name = "colStock"; colStock.ReadOnly = true; colStock.Width = 80;
            colStockMinimo.HeaderText = "Stock mínimo"; colStockMinimo.Name = "colStockMinimo"; colStockMinimo.ReadOnly = true; colStockMinimo.Width = 100;
            colPrecioCompra.HeaderText = "Precio compra"; colPrecioCompra.Name = "colPrecioCompra"; colPrecioCompra.ReadOnly = true; colPrecioCompra.Width = 120;
            colPrecioVenta.HeaderText = "Precio venta"; colPrecioVenta.Name = "colPrecioVenta"; colPrecioVenta.ReadOnly = true; colPrecioVenta.Width = 120;
            colEstado.HeaderText = "Estado"; colEstado.Name = "colEstado"; colEstado.ReadOnly = true; colEstado.Width = 95;
            // 
            // Frm_producto_listado
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 241, 242);
            ClientSize = new Size(1556, 867);
            Controls.Add(pnlContenido);
            Controls.Add(pnlEncabezado);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_producto_listado";
            Text = "Listado completo de productos";
            Load += Frm_producto_listado_Load;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            // ===== NK DESIGNER SYNC: mismo estilo visible al diseñar y al ejecutar =====
            BackColor = Color.FromArgb(248, 241, 242);
            pnlEncabezado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlEncabezado.FillColor = Color.White;
            pnlEncabezado.BorderRadius = 12;
            btnVolver.BorderRadius = 8;
            btnVolver.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.FillColor = Color.FromArgb(103, 53, 62);
            btnVolver.ForeColor = Color.White;
            btnVolver.HoverState.FillColor = Color.FromArgb(119, 68, 76);
            btnVolver.HoverState.ForeColor = Color.White;
            lblSubtitulo.Font = new Font("Book Antiqua", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Font = new Font("Book Antiqua", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(64, 0, 0);
            pnlContenido.BackColor = Color.Transparent;
            pnlContenido.FillColor = Color.White;
            pnlContenido.Radius = 12;
            pnlContenido.ShadowColor = Color.FromArgb(150, 205, 192, 195);
            pnlContenido.ShadowDepth = 16;
            pnlContenido.ShadowShift = 2;
            btnLimpiar.BorderRadius = 8;
            btnLimpiar.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.FillColor = Color.FromArgb(103, 53, 62);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.HoverState.FillColor = Color.FromArgb(119, 68, 76);
            btnLimpiar.HoverState.ForeColor = Color.White;
            lblOrden.Font = new Font("Book Antiqua", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.Font = new Font("Book Antiqua", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblColor.Font = new Font("Book Antiqua", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTalla.Font = new Font("Book Antiqua", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMarca.Font = new Font("Book Antiqua", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategoria.Font = new Font("Book Antiqua", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.Font = new Font("Book Antiqua", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbOrden.BorderRadius = 8;
            cmbOrden.BorderColor = Color.FromArgb(224, 210, 213);
            cmbOrden.FillColor = Color.FromArgb(252, 248, 249);
            cmbOrden.Font = new Font("Book Antiqua", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbOrden.ForeColor = Color.FromArgb(55, 43, 45);
            cmbEstado.BorderRadius = 8;
            cmbEstado.BorderColor = Color.FromArgb(224, 210, 213);
            cmbEstado.FillColor = Color.FromArgb(252, 248, 249);
            cmbEstado.Font = new Font("Book Antiqua", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstado.ForeColor = Color.FromArgb(55, 43, 45);
            cmbColor.BorderRadius = 8;
            cmbColor.BorderColor = Color.FromArgb(224, 210, 213);
            cmbColor.FillColor = Color.FromArgb(252, 248, 249);
            cmbColor.Font = new Font("Book Antiqua", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbColor.ForeColor = Color.FromArgb(55, 43, 45);
            cmbTalla.BorderRadius = 8;
            cmbTalla.BorderColor = Color.FromArgb(224, 210, 213);
            cmbTalla.FillColor = Color.FromArgb(252, 248, 249);
            cmbTalla.Font = new Font("Book Antiqua", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTalla.ForeColor = Color.FromArgb(55, 43, 45);
            cmbMarca.BorderRadius = 8;
            cmbMarca.BorderColor = Color.FromArgb(224, 210, 213);
            cmbMarca.FillColor = Color.FromArgb(252, 248, 249);
            cmbMarca.Font = new Font("Book Antiqua", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMarca.ForeColor = Color.FromArgb(55, 43, 45);
            cmbCategoria.BorderRadius = 8;
            cmbCategoria.BorderColor = Color.FromArgb(224, 210, 213);
            cmbCategoria.FillColor = Color.FromArgb(252, 248, 249);
            cmbCategoria.Font = new Font("Book Antiqua", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCategoria.ForeColor = Color.FromArgb(55, 43, 45);
            txtBuscar.BorderRadius = 8;
            txtBuscar.BorderColor = Color.FromArgb(224, 210, 213);
            txtBuscar.FillColor = Color.FromArgb(252, 248, 249);
            txtBuscar.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.ForeColor = Color.FromArgb(55, 43, 45);
            txtBuscar.PlaceholderForeColor = Color.FromArgb(175, 160, 164);
            txtBuscar.FocusedState.BorderColor = Color.FromArgb(103, 53, 62);
            lblResultados.Font = new Font("Book Antiqua", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventarioAyuda.Font = new Font("Book Antiqua", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInventarioAyuda.ForeColor = Color.FromArgb(105, 88, 91);
            lblInventario.Font = new Font("Book Antiqua", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(239, 226, 229);
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 0, 0);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Book Antiqua", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(64, 0, 0);
            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.ColumnHeadersHeight = 44;
            dgvProductos.DefaultCellStyle.Font = new Font("Book Antiqua", 8.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvProductos.DefaultCellStyle.BackColor = Color.White;
            dgvProductos.DefaultCellStyle.ForeColor = Color.FromArgb(55, 43, 45);
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 225, 228);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 0, 0);
            dgvProductos.DefaultCellStyle.Padding = new Padding(3);
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(253, 249, 250);
            dgvProductos.RowTemplate.Height = 38;
            pnlContenido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // ===== FIN NK DESIGNER SYNC =====
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlEncabezado;
        private Guna.UI2.WinForms.Guna2Button btnVolver;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlContenido;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Label lblOrden;
        private Label lblEstado;
        private Label lblColor;
        private Label lblTalla;
        private Label lblMarca;
        private Label lblCategoria;
        private Label lblBuscar;
        private Guna.UI2.WinForms.Guna2ComboBox cmbOrden;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEstado;
        private Guna.UI2.WinForms.Guna2ComboBox cmbColor;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTalla;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMarca;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategoria;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Label lblResultados;
        private Label lblInventarioAyuda;
        private Label lblInventario;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProductos;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colIdVariante;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colTalla;
        private DataGridViewTextBoxColumn colColor;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colStockMinimo;
        private DataGridViewTextBoxColumn colPrecioCompra;
        private DataGridViewTextBoxColumn colPrecioVenta;
        private DataGridViewTextBoxColumn colEstado;
    }
}
