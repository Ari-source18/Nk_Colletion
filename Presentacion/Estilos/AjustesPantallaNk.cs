using Guna.UI2.WinForms;

namespace NK_COLLECTION.Presentacion.Estilos;
internal static class AjustesPantallaNk
{
    public static void AplicarInicial(Form formulario)
    {
        formulario.AutoScroll = false;
        formulario.Padding = Padding.Empty;

        PrepararEstructuraComun(formulario);

        if (formulario.Name == "Frm_venta")
            PrepararVentas(formulario);
    }

    private static void PrepararEstructuraComun(Form formulario)
    {
        //ajustar encabezados
        foreach (Guna2Panel panel in formulario.Controls.OfType<Guna2Panel>())
        {
            if (panel.Top <= 40 && panel.Width >= formulario.ClientSize.Width * 0.70)
                panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        //ajustar tarjeta principal
        var tarjetas = formulario.Controls.OfType<Guna2ShadowPanel>().ToList();
        if (tarjetas.Count == 1)
        {
            var tarjeta = tarjetas[0];
            if (tarjeta.Width >= formulario.ClientSize.Width * 0.65 &&
                tarjeta.Height >= formulario.ClientSize.Height * 0.45)
            {
                tarjeta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }

        //ajustar tablas y pestañas
        foreach (var tabs in BuscarControles<TabControl>(formulario))
        {
            if (tabs.Parent != null && tabs.Width >= tabs.Parent.ClientSize.Width * 0.60)
                tabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        foreach (var grid in BuscarControles<DataGridView>(formulario))
        {
            if (grid.Parent != null && grid.Width >= grid.Parent.ClientSize.Width * 0.55)
                grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
    }

    private static void PrepararVentas(Form formulario)
    {
        //ocultar radios duplicados
        Ocultar(formulario, "rdb_Tarjeta");
        Ocultar(formulario, "rdb_Credito");
        Ocultar(formulario, "rdb_Efectivo");

        var panelCabecera = Buscar(formulario, "guna2Panel1");
        var panelDatos = Buscar(formulario, "guna2ShadowPanel1");
        var panelPago = Buscar(formulario, "guna2ShadowPanel2");
        var panelDetalle = Buscar(formulario, "guna2ShadowPanel3");

        if (panelCabecera != null)
            panelCabecera.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        if (panelDatos != null)
            panelDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

        if (panelPago != null)
            panelPago.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

        if (panelDetalle != null)
            panelDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        var grid = Buscar(formulario, "dgw_ventas") as DataGridView;
        if (grid != null)
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        //ajustar totales
        ReubicarEtiqueta(formulario, "lbl_subtotal", "Subtotal:", 28, 420);
        ReubicarEtiqueta(formulario, "lbl_descuento", "Descuento:", 28, 478);
        ReubicarEtiqueta(formulario, "lbl_total", "Total:", 28, 530);
        ReubicarEtiqueta(formulario, "lbl_cambio", "Cambio:", 28, 578);

        foreach (string nombre in new[] { "lbl_subtotalF", "lbl_descuentoF", "lbl_totalF", "lbl_cambioF" })
        {
            if (Buscar(formulario, nombre) is Label valor)
            {
                valor.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                valor.Font = EstiloNk.Fuente(valor.Font, 10F, FontStyle.Bold);
            }
        }

        //ordenar métodos de pago
        foreach (string nombre in new[] { "rdbtn_tarjeta", "rdbtn_credito", "rdbtn_efectivo" })
        {
            if (Buscar(formulario, nombre) is RadioButton radio)
                radio.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }
    }

    private static void ReubicarEtiqueta(Form formulario, string nombre, string texto, int x, int y)
    {
        if (Buscar(formulario, nombre) is not Label label)
            return;

        label.Text = texto;
        label.Location = new Point(x, y);
        label.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        label.Font = EstiloNk.Fuente(label.Font, 9.5F, FontStyle.Bold);
        label.ForeColor = EstiloNk.Vino;
    }

    private static void Ocultar(Form formulario, string nombre)
    {
        var control = Buscar(formulario, nombre);
        if (control != null)
        {
            control.Visible = false;
            control.Enabled = false;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }
    }

    internal static Control? Buscar(Control raiz, string nombre)
    {
        if (raiz.Name == nombre)
            return raiz;

        foreach (Control hijo in raiz.Controls)
        {
            var encontrado = Buscar(hijo, nombre);
            if (encontrado != null)
                return encontrado;
        }

        return null;
    }

    private static IEnumerable<T> BuscarControles<T>(Control raiz) where T : Control
    {
        foreach (Control hijo in raiz.Controls)
        {
            if (hijo is T tipo)
                yield return tipo;

            foreach (var nieto in BuscarControles<T>(hijo))
                yield return nieto;
        }
    }
}
