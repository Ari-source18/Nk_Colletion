namespace NK_COLLECTION.Presentacion.Estilos;
internal static class DisenoResponsivoNk
{
    private static readonly Dictionary<Form, EstadoFormulario> Estados = new();

    public static void Habilitar(Form formulario)
    {
        if (Estados.ContainsKey(formulario))
            return;

        var estado = new EstadoFormulario(formulario);
        Estados[formulario] = estado;

        formulario.Resize += (_, _) => estado.Aplicar();
        formulario.Shown += (_, _) => estado.Aplicar();
        formulario.Disposed += (_, _) => Estados.Remove(formulario);

        estado.Aplicar();
    }

    private sealed class EstadoFormulario
    {
        private readonly Form _formulario;
        private readonly List<RegistroControl> _registros = new();
        private bool _aplicando;

        public EstadoFormulario(Form formulario)
        {
            _formulario = formulario;
            Capturar(formulario);
        }

        private void Capturar(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                _registros.Add(new RegistroControl(
                    control,
                    control.Bounds,
                    control.Parent?.ClientSize ?? Size.Empty,
                    control.Font,
                    control.Anchor,
                    control.Dock,
                    control.AutoSize));

                if (control.HasChildren)
                    Capturar(control);
            }
        }

        public void Aplicar()
        {
            if (_aplicando || _formulario.IsDisposed || _formulario.ClientSize.Width <= 0 || _formulario.ClientSize.Height <= 0)
                return;

            _aplicando = true;
            try
            {
                _formulario.SuspendLayout();

                if (_formulario.Name == "Frm_venta")
                    AjustarEstructuraVenta();

                foreach (var registro in _registros)
                    AjustarControl(registro);
            }
            finally
            {
                _formulario.ResumeLayout(true);
                _aplicando = false;
            }
        }

        private void AjustarControl(RegistroControl registro)
        {
            var control = registro.Control;
            var parent = control.Parent;

            if (control.IsDisposed || parent == null || registro.ParentOriginal.Width <= 0 || registro.ParentOriginal.Height <= 0)
                return;

            //respetar dock y anchor
            if (registro.Dock != DockStyle.None)
            {
                AjustarFuente(control, registro, 1F);
                return;
            }

            if (registro.Anchor != (AnchorStyles.Top | AnchorStyles.Left))
            {
                float escalaFuenteAnclada = Math.Clamp(
                    Math.Min((float)parent.ClientSize.Width / registro.ParentOriginal.Width,
                             (float)parent.ClientSize.Height / registro.ParentOriginal.Height),
                    0.82F,
                    1.08F);
                AjustarFuente(control, registro, escalaFuenteAnclada);
                return;
            }

            float sx = (float)parent.ClientSize.Width / registro.ParentOriginal.Width;
            float sy = (float)parent.ClientSize.Height / registro.ParentOriginal.Height;

            //validar escala
            if (sx <= 0 || sy <= 0)
                return;

            int x = (int)Math.Round(registro.BoundsOriginal.X * sx);
            int y = (int)Math.Round(registro.BoundsOriginal.Y * sy);
            int ancho = Math.Max(1, (int)Math.Round(registro.BoundsOriginal.Width * sx));
            int alto = Math.Max(1, (int)Math.Round(registro.BoundsOriginal.Height * sy));

            if (registro.AutoSize && control is Label or RadioButton or CheckBox)
                control.Location = new Point(x, y);
            else
                control.Bounds = new Rectangle(x, y, ancho, alto);

            float escalaFuente = Math.Clamp(Math.Min(sx, sy), 0.76F, 1.10F);
            AjustarFuente(control, registro, escalaFuente);
        }

        private static void AjustarFuente(Control control, RegistroControl registro, float escala)
        {
            if (registro.FuenteOriginal == null || control is DataGridView)
                return;

            float nuevoTamano = Math.Max(7.5F, registro.FuenteOriginal.Size * escala);

            // Evita recrear fuentes si el cambio es imperceptible.
            if (Math.Abs(control.Font.Size - nuevoTamano) < 0.15F && control.Font.FontFamily.Name == "Book Antiqua")
                return;

            try
            {
                control.Font = new Font("Book Antiqua", nuevoTamano, registro.FuenteOriginal.Style, registro.FuenteOriginal.Unit);
            }
            catch
            {
                // Si la fuente no está disponible, se mantiene la existente.
            }
        }

        private void AjustarEstructuraVenta()
        {
            var cabecera = AjustesPantallaNk.Buscar(_formulario, "guna2Panel1");
            var datos = AjustesPantallaNk.Buscar(_formulario, "guna2ShadowPanel1");
            var pago = AjustesPantallaNk.Buscar(_formulario, "guna2ShadowPanel2");
            var detalle = AjustesPantallaNk.Buscar(_formulario, "guna2ShadowPanel3");

            if (cabecera == null || datos == null || pago == null || detalle == null)
                return;

            int ancho = _formulario.ClientSize.Width;
            int alto = _formulario.ClientSize.Height;
            int margen = Math.Clamp(ancho / 80, 12, 22);
            int separacion = Math.Clamp(ancho / 120, 9, 14);
            int altoCabecera = Math.Clamp(alto / 9, 82, 100);
            int yContenido = margen + altoCabecera + 10;
            int altoContenido = Math.Max(260, alto - yContenido - margen);
            int anchoUtil = Math.Max(520, ancho - (margen * 2) - (separacion * 2));

            int anchoDatos = Math.Clamp((int)(anchoUtil * 0.27), 185, 400);
            int anchoPago = Math.Clamp((int)(anchoUtil * 0.23), 175, 344);
            int anchoDetalle = anchoUtil - anchoDatos - anchoPago;

            if (anchoDetalle < 250)
            {
                int falta = 250 - anchoDetalle;
                int reducirDatos = Math.Min(falta / 2, Math.Max(0, anchoDatos - 175));
                int reducirPago = Math.Min(falta - reducirDatos, Math.Max(0, anchoPago - 165));
                anchoDatos -= reducirDatos;
                anchoPago -= reducirPago;
                anchoDetalle = anchoUtil - anchoDatos - anchoPago;
            }

            cabecera.Bounds = new Rectangle(margen, margen, Math.Max(300, ancho - margen * 2), altoCabecera);
            datos.Bounds = new Rectangle(margen, yContenido, anchoDatos, altoContenido);
            detalle.Bounds = new Rectangle(margen + anchoDatos + separacion, yContenido, Math.Max(220, anchoDetalle), altoContenido);
            pago.Bounds = new Rectangle(margen + anchoDatos + separacion + Math.Max(220, anchoDetalle) + separacion, yContenido, anchoPago, altoContenido);

            if (AjustesPantallaNk.Buscar(_formulario, "dgw_ventas") is DataGridView grid)
            {
                int p = 14;
                grid.Bounds = new Rectangle(p, p, Math.Max(180, detalle.ClientSize.Width - p * 2), Math.Max(180, detalle.ClientSize.Height - p * 2));
            }
        }
    }

    private sealed record RegistroControl(
        Control Control,
        Rectangle BoundsOriginal,
        Size ParentOriginal,
        Font FuenteOriginal,
        AnchorStyles Anchor,
        DockStyle Dock,
        bool AutoSize);
}
