using NK_COLLECTION.Negocios.Catalogos;
using NK_COLLECTION.Presentacion.Caja;
using NK_COLLECTION.Presentacion.Catalogos;
using NK_COLLECTION.Presentacion.Compras;
using NK_COLLECTION.Presentacion.Mantenimiento;
using NK_COLLECTION.Presentacion.Productos;
using NK_COLLECTION.Presentacion.Reportes;
using NK_COLLECTION.Presentacion.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace NK_COLLECTION.Presentacion.Principal
{
    
    public partial class Frm_main : Form
    {
        private readonly UsuarioService _usuarioService;
        public Frm_main()
        {
            InitializeComponent();
        }

        // Nuevo constructor que recibe el servicio de usuarios
        public Frm_main(UsuarioService usuarioService)
        {
            InitializeComponent();

            _usuarioService = usuarioService;
        }

        public void AbrirFormularioEnPanel(Form formulario)
        {
            Panel_Hijo.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            Panel_Hijo.Controls.Add(formulario);
            Panel_Hijo.Tag = formulario;

            formulario.Show();
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {

        }

        private void Panel_Padre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel_Hijo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_usuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Frm_usuario(_usuarioService));
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
            AbrirFormularioEnPanel(new Frm_categoria());
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
            this.Close();
        }
    }
}
