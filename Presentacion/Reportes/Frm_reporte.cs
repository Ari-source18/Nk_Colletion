using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NK_COLLECTION.Presentacion.Reportes
{
    public partial class Frm_reporte : Form
    {
        public Frm_reporte()
        {
            InitializeComponent();
            NK_COLLECTION.Presentacion.Estilos.EstiloNk.Preparar(this);
        }
    }
}
