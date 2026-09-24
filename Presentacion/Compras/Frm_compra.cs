using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NK_COLLECTION.Presentacion.Compras
{
    public partial class Frm_compra : Form
    {
        public Frm_compra()
        {
            InitializeComponent();
            // El estilo dinámico solo se aplica al ejecutar. En el Designer se usan
            // las propiedades ya guardadas en InitializeComponent para que sea editable.
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
                NK_COLLECTION.Presentacion.Estilos.EstiloNk.Preparar(this);
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
