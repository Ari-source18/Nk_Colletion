using Guna.UI2.WinForms;
using NK_COLLECTION.Presentacion.Caja;
using NK_COLLECTION.Presentacion.Catalogos;
using NK_COLLECTION.Presentacion.Compras;
using NK_COLLECTION.Presentacion.Estilos;
using NK_COLLECTION.Presentacion.Mantenimiento;
using NK_COLLECTION.Presentacion.Productos;
using NK_COLLECTION.Presentacion.Reportes;
using NK_COLLECTION.Presentacion.Ventas;

namespace NK_COLLECTION.Presentacion.Principal
{
    public partial class Frm_main : Form
    {
        private Guna2Button[] _botonesMenu = Array.Empty<Guna2Button>();

        public Frm_main()
        {
            InitializeComponent();
            MinimumSize = new Size(1050, 650);
            StartPosition = FormStartPosition.CenterScreen;
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
                ConfigurarMenuResponsivo();
        }

        private void ConfigurarMenuResponsivo()
        {
            _botonesMenu = new[]
            {
                btn_usuarios,
                btn_clientes,
                btnproveedores,
                btncompras,
                btnproductos,
                btncaja,
                btnventas,
                btndevolucion,
                btncredito,
                btnreporte,
                btnmantenimiento,
                btnacercade
            };

            // Controles antiguos que quedaron rezagados en el Designer original.
            // Se ocultan para que no interfieran con el escalado del menú actual.
            label1.Visible = false;
            lbl_Cerrar_sesion.Visible = false;
            btn_Acerca_de.Visible = false;
            btn_Mantenimiento.Visible = false;
            btn_Reporte.Visible = false;
            btn_Inventario.Visible = false;
            btn_Credito.Visible = false;
            btn_Devolucion.Visible = false;
            btn_Ventas.Visible = false;
            btn_Caja.Visible = false;
            btn_Productos.Visible = false;
            btn_Compras.Visible = false;
            btn_Proveedores.Visible = false;

            foreach (var boton in _botonesMenu)
            {
                boton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                boton.Font = new Font("Book Antiqua", 10F);
                boton.FillColor = Color.Transparent;
                boton.HoverState.FillColor = Color.FromArgb(98, 48, 56);
                boton.ImageOffset = new Point(18, 0);
            }

            btn_cerrar_sesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_cerrar_sesion.Font = new Font("Book Antiqua", 10F, FontStyle.Bold);
            btn_cerrar_sesion.FillColor = Color.Transparent;
            btn_cerrar_sesion.HoverState.FillColor = Color.FromArgb(98, 48, 56);

            Panel_Padre.Resize += (_, _) => AjustarMenuResponsivo();
            Resize += (_, _) => AjustarMenuResponsivo();
            AjustarMenuResponsivo();
        }

        private void AjustarMenuResponsivo()
        {
            if (_botonesMenu.Length == 0 || Panel_Padre.ClientSize.Height <= 0)
                return;

            // El ancho lateral también se adapta al modo ventana sin robar
            // espacio innecesario al contenido principal.
            int anchoDeseado = Math.Clamp((int)(ClientSize.Width * 0.14), 205, 251);
            if (Panel_Padre.Width != anchoDeseado)
                Panel_Padre.Width = anchoDeseado;

            int ancho = Panel_Padre.ClientSize.Width;
            int margenSuperior = 8;
            int margenInferior = 6;
            int altoCerrar = Math.Clamp(Panel_Padre.ClientSize.Height / 14, 48, 60);

            // El menú comienza justo debajo del logo y termina exactamente
            // donde empieza Cerrar sesión: no quedan huecos grandes vacíos.
            int inicioMenu = Math.Max(panel1.Bottom + 8, 105);
            int finMenu = Math.Max(inicioMenu + _botonesMenu.Length,
                Panel_Padre.ClientSize.Height - altoCerrar - margenInferior);
            int espacioDisponible = Math.Max(_botonesMenu.Length, finMenu - inicioMenu);
            int altoBase = Math.Max(30, espacioDisponible / _botonesMenu.Length);
            int sobrante = Math.Max(0, espacioDisponible - altoBase * _botonesMenu.Length);

            panel1.Location = new Point(Math.Max(0, (ancho - panel1.Width) / 2), margenSuperior);

            int y = inicioMenu;
            for (int i = 0; i < _botonesMenu.Length; i++)
            {
                var boton = _botonesMenu[i];
                int alto = altoBase + (i < sobrante ? 1 : 0);
                boton.Location = new Point(0, y);
                boton.Size = new Size(ancho, alto);
                y += alto;
            }

            btn_cerrar_sesion.Location = new Point(0, Panel_Padre.ClientSize.Height - altoCerrar);
            btn_cerrar_sesion.Size = new Size(ancho, altoCerrar);
        }

        public void AbrirFormularioEnPanel(Form formulario)
        {
            foreach (Control control in Panel_Hijo.Controls.Cast<Control>().ToList())
                control.Dispose();

            Panel_Hijo.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            // Da uniformidad visual a cada módulo sin tocar sus eventos ni su lógica.
            EstiloNk.Preparar(formulario);

            Panel_Hijo.Controls.Add(formulario);
            Panel_Hijo.Tag = formulario;

            formulario.BringToFront();
            formulario.Show();
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            AjustarMenuResponsivo();
        }

        private void Panel_Padre_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Panel_Hijo_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btn_usuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_usuario());
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_clientes());
        }

        private void btnproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_proveedores());
        }

        private void btncategoria_Click(object sender, EventArgs e)
        {
            // Las categorías se gestionan desde Productos para mantener
            // el flujo de catálogos asociado al registro de prendas.
        }

        private void btncompras_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_compra());
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_producto());
        }

        private void btncaja_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Caja_principal());
        }

        private void btnventas_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_venta());
        }

        private void btndevolucion_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_devoluciones());
        }

        private void btncredito_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_credito());
        }

        private void btnreporte_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_reporte());
        }

        private void btnmantenimiento_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_mantenimiento());
        }

        private void btn_cerrar_sesion_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
