using NK_COLLECTION.Presentacion.Principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NK_COLLECTION.Presentacion.Caja
{
    public partial class Frm_apertura : Form
    {
        public Frm_apertura()
        {
            InitializeComponent();
            // El estilo dinámico solo se aplica al ejecutar. En el Designer se usan
            // las propiedades ya guardadas en InitializeComponent para que sea editable.
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
                NK_COLLECTION.Presentacion.Estilos.EstiloNk.Preparar(this);
        }

        private void Frm_apertura_Load(object sender, EventArgs e)
        {

        }

        private void btn_aperturar_Click(object sender, EventArgs e)
        {
            Frm_main main = new Frm_main();
            main.Show();
            this.Hide();
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
