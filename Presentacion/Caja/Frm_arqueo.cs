using NK_COLLECTION.Presentacion.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NK_COLLECTION.Presentacion.Caja
{
    public partial class Frm_arqueo : Form
    {
        public Frm_arqueo()
        {
            InitializeComponent();
            // El estilo dinámico solo se aplica al ejecutar. En el Designer se usan
            // las propiedades ya guardadas en InitializeComponent para que sea editable.
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
                NK_COLLECTION.Presentacion.Estilos.EstiloNk.Preparar(this);
        }
         
        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm_arqueo_Load(object sender, EventArgs e)
        {

        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {

        }
    }
}
