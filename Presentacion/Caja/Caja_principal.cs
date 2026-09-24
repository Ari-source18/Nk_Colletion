using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NK_COLLECTION.Presentacion.Caja
{
    public partial class Caja_principal : Form
    {
        public Caja_principal()
        {
            InitializeComponent();
            // El estilo dinámico solo se aplica al ejecutar. En el Designer se usan
            // las propiedades ya guardadas en InitializeComponent para que sea editable.
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
                NK_COLLECTION.Presentacion.Estilos.EstiloNk.Preparar(this);
        }

        private void Caja_principal_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Frm_arqueo arqueo = new Frm_arqueo();
            arqueo.Show();
            this.Hide();
        }

        private void guna2ShadowPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_controlegresos_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_cierredecaja_Click(object sender, EventArgs e)
        {
            Frm_cierre_caja cierredecaja = new Frm_cierre_caja();
            cierredecaja.Show();
            this.Hide();
        }
    }
}
