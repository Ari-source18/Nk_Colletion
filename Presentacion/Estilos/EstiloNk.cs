using Guna.UI2.WinForms;

namespace NK_COLLECTION.Presentacion.Estilos;
internal static class EstiloNk
{
    private static readonly HashSet<TabControl> TabsConfigurados = new();
    public static readonly Color Vino = Color.FromArgb(64, 0, 0);
    public static readonly Color VinoSecundario = Color.FromArgb(103, 53, 62);
    public static readonly Color Fondo = Color.FromArgb(248, 241, 242);
    public static readonly Color Superficie = Color.White;
    public static readonly Color Campo = Color.FromArgb(252, 248, 249);
    public static readonly Color Borde = Color.FromArgb(224, 210, 213);
    public static readonly Color TextoSuave = Color.FromArgb(105, 88, 91);
    public static readonly Color Seleccion = Color.FromArgb(241, 225, 228);

    public static void Preparar(Form formulario)
    {
        Aplicar(formulario);
        AjustesPantallaNk.AplicarInicial(formulario);
        DisenoResponsivoNk.Habilitar(formulario);
    }

    public static void Aplicar(Form formulario)
    {
        formulario.BackColor = Fondo;
        AplicarRecursivo(formulario);
    }

    private static void AplicarRecursivo(Control contenedor)
    {
        foreach (Control control in contenedor.Controls)
        {
            switch (control)
            {
                case Guna2ShadowPanel tarjeta:
                    AplicarTarjeta(tarjeta);
                    break;

                case Guna2Panel panelGuna:
                    AplicarPanelGuna(panelGuna);
                    break;

                case Guna2Button boton:
                    AplicarBoton(boton);
                    break;

                case Guna2TextBox texto:
                    AplicarTextoGuna(texto);
                    break;

                case Guna2ComboBox combo:
                    AplicarComboGuna(combo);
                    break;

                case Guna2DateTimePicker fechaGuna:
                    AplicarFechaGuna(fechaGuna);
                    break;

                case Guna2DataGridView gunaGrid:
                    AplicarGrid(gunaGrid);
                    break;

                case DataGridView grid:
                    AplicarGrid(grid);
                    break;

                case TextBox textoNormal:
                    AplicarTextoNormal(textoNormal);
                    break;

                case ComboBox comboNormal:
                    AplicarComboNormal(comboNormal);
                    break;

                case NumericUpDown numero:
                    AplicarNumero(numero);
                    break;

                case DateTimePicker fecha:
                    AplicarFecha(fecha);
                    break;

                case RadioButton radio:
                    radio.Font = Fuente(radio.Font, Math.Max(8.5F, radio.Font.Size));
                    radio.ForeColor = Vino;
                    break;

                case GroupBox grupo:
                    grupo.Font = Fuente(grupo.Font, Math.Max(9F, grupo.Font.Size), FontStyle.Bold);
                    grupo.ForeColor = Vino;
                    grupo.BackColor = Superficie;
                    break;

                case TabControl tabs:
                    AplicarTabs(tabs);
                    break;

                case TabPage pagina:
                    pagina.BackColor = Superficie;
                    pagina.ForeColor = Vino;
                    break;

                case Label label:
                    AplicarLabel(label);
                    break;

                case Button botonNormal:
                    AplicarBotonNormal(botonNormal);
                    break;

                case Panel panel:
                    AplicarPanelNormal(panel);
                    break;
            }

            if (control.HasChildren)
                AplicarRecursivo(control);
        }
    }

    private static void AplicarTarjeta(Guna2ShadowPanel tarjeta)
    {
        tarjeta.BackColor = Color.Transparent;
        tarjeta.FillColor = Superficie;
        tarjeta.Radius = Math.Max(tarjeta.Radius, 12);
        tarjeta.ShadowColor = Color.FromArgb(150, 205, 192, 195);
        tarjeta.ShadowDepth = Math.Min(Math.Max(tarjeta.ShadowDepth, 8), 16);
        tarjeta.ShadowShift = Math.Min(Math.Max(tarjeta.ShadowShift, 1), 3);
    }

    private static void AplicarPanelGuna(Guna2Panel panel)
    {
        //estilo de paneles
        if (EsColorClaro(panel.FillColor) || EsColorClaro(panel.BackColor))
        {
            panel.FillColor = Superficie;
            if (panel.Height > 45)
                panel.BorderRadius = Math.Max(panel.BorderRadius, 12);
        }
    }

    private static void AplicarPanelNormal(Panel panel)
    {
        //mantener bordes vino
        if (panel.Width <= 12 || panel.Height <= 12)
        {
            panel.BackColor = Vino;
            return;
        }

        if (EsColorClaro(panel.BackColor))
            panel.BackColor = Superficie;
    }

    private static void AplicarLabel(Label label)
    {
        FontStyle estilo = label.Font.Style;
        if (label.Font.Size >= 17F)
            estilo = FontStyle.Bold;

        label.Font = Fuente(label.Font, label.Font.Size, estilo);

        if (label.Font.Size >= 17F)
            label.ForeColor = Vino;
        else if (label.ForeColor == Color.Gray || label.ForeColor == Color.DimGray)
            label.ForeColor = TextoSuave;
    }

    private static void AplicarBoton(Guna2Button boton)
    {
        boton.BorderRadius = Math.Max(boton.BorderRadius, 8);
        boton.Font = Fuente(boton.Font, Math.Max(8.5F, boton.Font.Size), FontStyle.Bold);
        boton.Cursor = Cursors.Hand;

        bool secundario = EsAccionSecundaria(boton.Text);
        boton.FillColor = secundario ? VinoSecundario : Vino;
        boton.ForeColor = Color.White;
        boton.HoverState.FillColor = secundario ? Color.FromArgb(119, 68, 76) : Color.FromArgb(88, 18, 24);
        boton.HoverState.ForeColor = Color.White;
    }

    private static void AplicarBotonNormal(Button boton)
    {
        boton.Font = Fuente(boton.Font, Math.Max(8.5F, boton.Font.Size), FontStyle.Bold);
        boton.Cursor = Cursors.Hand;
        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;
        boton.BackColor = EsAccionSecundaria(boton.Text) ? VinoSecundario : Vino;
        boton.ForeColor = Color.White;
        boton.UseVisualStyleBackColor = false;
    }

    private static void AplicarTextoGuna(Guna2TextBox texto)
    {
        texto.BorderRadius = Math.Max(texto.BorderRadius, 8);
        texto.BorderColor = Borde;
        texto.FillColor = texto.ReadOnly ? Color.FromArgb(245, 239, 240) : Campo;
        texto.Font = Fuente(texto.Font, Math.Max(8.5F, texto.Font.Size));
        texto.ForeColor = Color.FromArgb(55, 43, 45);
        texto.PlaceholderForeColor = Color.FromArgb(175, 160, 164);
        texto.FocusedState.BorderColor = VinoSecundario;
    }

    private static void AplicarComboGuna(Guna2ComboBox combo)
    {
        combo.BorderRadius = Math.Max(combo.BorderRadius, 8);
        combo.BorderColor = Borde;
        combo.FillColor = Campo;
        combo.Font = Fuente(combo.Font, Math.Max(8.5F, combo.Font.Size));
        combo.ForeColor = Color.FromArgb(55, 43, 45);
    }

    private static void AplicarFechaGuna(Guna2DateTimePicker fecha)
    {
        fecha.FillColor = Campo;
        fecha.ForeColor = Color.FromArgb(55, 43, 45);
        fecha.Font = Fuente(fecha.Font, Math.Max(8.5F, fecha.Font.Size));
    }

    private static void AplicarTextoNormal(TextBox texto)
    {
        texto.Font = Fuente(texto.Font, Math.Max(8.5F, texto.Font.Size));
        texto.BackColor = texto.ReadOnly ? Color.FromArgb(245, 239, 240) : Campo;
        texto.ForeColor = Color.FromArgb(55, 43, 45);
        texto.BorderStyle = BorderStyle.FixedSingle;
    }

    private static void AplicarComboNormal(ComboBox combo)
    {
        combo.Font = Fuente(combo.Font, Math.Max(8.5F, combo.Font.Size));
        combo.BackColor = Campo;
        combo.ForeColor = Color.FromArgb(55, 43, 45);
        combo.FlatStyle = FlatStyle.Flat;
    }

    private static void AplicarNumero(NumericUpDown numero)
    {
        numero.Font = Fuente(numero.Font, Math.Max(8.5F, numero.Font.Size));
        numero.BackColor = Campo;
        numero.ForeColor = Color.FromArgb(55, 43, 45);
        numero.BorderStyle = BorderStyle.FixedSingle;
    }

    private static void AplicarFecha(DateTimePicker fecha)
    {
        fecha.Font = Fuente(fecha.Font, Math.Max(8.5F, fecha.Font.Size));
        fecha.CalendarForeColor = Color.FromArgb(55, 43, 45);
        fecha.CalendarMonthBackground = Campo;
    }

    private static void AplicarTabs(TabControl tabs)
    {
        tabs.Font = Fuente(tabs.Font, Math.Max(9F, tabs.Font.Size), FontStyle.Bold);
        tabs.Padding = new Point(16, 6);
        tabs.SizeMode = TabSizeMode.Normal;
        tabs.DrawMode = TabDrawMode.OwnerDrawFixed;

        if (TabsConfigurados.Add(tabs))
        {
            tabs.DrawItem += DibujarTab;
            tabs.Disposed += (_, _) => TabsConfigurados.Remove(tabs);
        }
    }

    private static void DibujarTab(object? sender, DrawItemEventArgs e)
    {
        if (sender is not TabControl tabs || e.Index < 0 || e.Index >= tabs.TabPages.Count)
            return;

        Rectangle rect = tabs.GetTabRect(e.Index);
        bool seleccionado = e.Index == tabs.SelectedIndex;

        using var fondo = new SolidBrush(seleccionado ? Vino : Color.FromArgb(245, 236, 238));
        using var texto = new SolidBrush(seleccionado ? Color.White : Vino);
        e.Graphics.FillRectangle(fondo, rect);

        TextRenderer.DrawText(
            e.Graphics,
            tabs.TabPages[e.Index].Text,
            tabs.Font,
            rect,
            texto.Color,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }

    private static void AplicarGrid(DataGridView grid)
    {
        grid.BackgroundColor = Superficie;
        grid.BorderStyle = BorderStyle.None;
        grid.EnableHeadersVisualStyles = false;
        grid.GridColor = Color.FromArgb(239, 226, 229);
        grid.RowHeadersVisible = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;

        grid.ColumnHeadersDefaultCellStyle.BackColor = Vino;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Book Antiqua", 9F, FontStyle.Bold);
        grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Vino;
        grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        grid.ColumnHeadersHeight = Math.Max(grid.ColumnHeadersHeight, 34);

        grid.DefaultCellStyle.Font = new Font("Book Antiqua", 8.8F, FontStyle.Regular);
        grid.DefaultCellStyle.BackColor = Superficie;
        grid.DefaultCellStyle.ForeColor = Color.FromArgb(55, 43, 45);
        grid.DefaultCellStyle.SelectionBackColor = Seleccion;
        grid.DefaultCellStyle.SelectionForeColor = Vino;
        grid.DefaultCellStyle.Padding = new Padding(3);

        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(253, 249, 250);
        grid.RowTemplate.Height = Math.Max(grid.RowTemplate.Height, 31);

        if (grid.Columns.Count > 0 && grid.Columns.Count <= 8)
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private static bool EsAccionSecundaria(string? texto)
    {
        string valor = (texto ?? string.Empty).Trim().ToLowerInvariant();
        return valor.Contains("limpiar") ||
               valor.Contains("cancelar") ||
               valor.Contains("volver") ||
               valor.Contains("quitar") ||
               valor.Contains("editar") ||
               valor.Contains("nueva ") ||
               valor.Contains("nuevo ") ||
               valor.Contains("gestionar");
    }

    private static bool EsColorClaro(Color color)
    {
        if (color == Color.Transparent || color == Color.Empty)
            return false;

        return color.R >= 225 && color.G >= 225 && color.B >= 225;
    }

    internal static Font Fuente(Font original, float tamano, FontStyle? estilo = null)
    {
        try
        {
            return new Font("Book Antiqua", tamano, estilo ?? original.Style, original.Unit);
        }
        catch
        {
            return original;
        }
    }
}
