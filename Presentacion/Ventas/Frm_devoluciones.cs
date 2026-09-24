using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NK_COLLECTION.Presentacion.Ventas
{
    public partial class Frm_devoluciones : Form
    {
        public Frm_devoluciones()
        {
            InitializeComponent();
            // El estilo dinámico solo se aplica al ejecutar. En el Designer se usan
            // las propiedades ya guardadas en InitializeComponent para que sea editable.
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
                NK_COLLECTION.Presentacion.Estilos.EstiloNk.Preparar(this);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
