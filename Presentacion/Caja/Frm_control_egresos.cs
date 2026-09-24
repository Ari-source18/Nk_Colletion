using Microsoft.EntityFrameworkCore;
using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;
using NK_COLLECTION.Negocios.Caja;

namespace NK_COLLECTION.Presentacion.Caja
{
    public partial class Frm_control_egresos : Form
    {
        private readonly DbContextOptions<NkCollectionContext> _options;
        private readonly Egreso_Service _egresoService;

        public Frm_control_egresos(
            DbContextOptions<NkCollectionContext> options)
        {
            InitializeComponent();

            _options = options;

            _egresoService =
                new Egreso_Service(options);

            btn_guardar_movimiento.Click +=
                btn_guardar_movimiento_Click;
        }


        // CARGAR FORMULARIO
        private async void Frm_control_egresos_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                lbl_fecha.Text =
                    $"Fecha: {DateTime.Now:dd/MM/yyyy}";

                // CAMPOS DE TOTALES SOLO LECTURA
                txtbox_total_egreso.ReadOnly = true;

                txtbox_total_dinero_egresado.ReadOnly = true;

                // CONFIGURAR TABLA
                ConfigurarDataGridView();

                // CARGAR DATOS
                await CargarEgresosAsync();

                await CargarTotalesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // CONFIGURAR DATAGRIDVIEW
        private void ConfigurarDataGridView()
        {
            dgw_control_egresos.AutoGenerateColumns = false;

            dgw_control_egresos.AllowUserToAddRows = false;

            dgw_control_egresos.AllowUserToDeleteRows = false;

            dgw_control_egresos.ReadOnly = true;

            dgw_control_egresos.MultiSelect = false;

            dgw_control_egresos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }


        // CARGAR EGRESOS EN LA TABLA
        private async Task CargarEgresosAsync()
        {
            var lista =
                await _egresoService.ListarActivosAsync();

            dgw_control_egresos.Rows.Clear();

            foreach (var egreso in lista)
            {
                dgw_control_egresos.Rows.Add(
                    egreso.FechaEgreso.HasValue
                        ? egreso.FechaEgreso.Value
                            .ToString("dd/MM/yyyy HH:mm")
                        : "",

                    egreso.IdTipoEgresoNavigation?.Nombre
                        ?? "Sin tipo",

                    egreso.Descripcion ?? "",

                    $"C$ {egreso.Monto:N2}"
                );
            }

            dgw_control_egresos.ClearSelection();
        }


        // CARGAR TOTALES
        private async Task CargarTotalesAsync()
        {
            int cantidad =
                await _egresoService
                    .ObtenerCantidadEgresosAsync();

            decimal total =
                await _egresoService
                    .ObtenerTotalEgresadoAsync();

            txtbox_total_egreso.Text =
                cantidad.ToString();

            txtbox_total_dinero_egresado.Text =
                $"C$ {total:N2}";
        }


        // BOTÓN GUARDAR MOVIMIENTO
        private async void btn_guardar_movimiento_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                btn_guardar_movimiento.Enabled = false;

                // VALIDAR TIPO
                if (string.IsNullOrWhiteSpace(
                    txtbox_tipo_egreso.Text))
                {
                    MessageBox.Show(
                        "Ingrese el tipo de egreso.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtbox_tipo_egreso.Focus();

                    return;
                }


                // VALIDAR RESPONSABLE
                if (string.IsNullOrWhiteSpace(
                    txtbox_responsable.Text))
                {
                    MessageBox.Show(
                        "Ingrese el responsable.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtbox_responsable.Focus();

                    return;
                }


                // VALIDAR MONTO
                if (!decimal.TryParse(
                    txtbox_monto.Text.Trim(),
                    out decimal monto))
                {
                    MessageBox.Show(
                        "Ingrese un monto válido.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtbox_monto.Focus();

                    return;
                }


                if (monto <= 0)
                {
                    MessageBox.Show(
                        "El monto debe ser mayor que cero.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtbox_monto.Focus();

                    return;
                }


                // OBTENER APERTURA ACTIVA
                int idAperturaCaja =
                    await ObtenerAperturaCajaActivaAsync();


                // OBTENER O CREAR TIPO DE EGRESO
                int idTipoEgreso =
                    await ObtenerTipoEgresoAsync(
                        txtbox_tipo_egreso.Text);


                // GUARDAR
                await _egresoService.GuardarAsync(
                    idAperturaCaja,
                    idTipoEgreso,
                    monto,

                    // TEMPORALMENTE RESPONSABLE
                    // SE GUARDA EN DESCRIPCIÓN
                    txtbox_responsable.Text.Trim()
                );


                MessageBox.Show(
                    "Egreso registrado correctamente.",
                    "NK Collection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                // LIMPIAR
                LimpiarCampos();


                // REFRESCAR TABLA
                await CargarEgresosAsync();


                // REFRESCAR TOTALES
                await CargarTotalesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btn_guardar_movimiento.Enabled = true;
            }
        }


        // OBTENER APERTURA DE CAJA ACTIVA
        private async Task<int>
            ObtenerAperturaCajaActivaAsync()
        {
            await using var contexto =
                new NkCollectionContext(_options);

            var apertura =
                await contexto.AperturaCajas
                    .AsNoTracking()
                    .Where(a =>
                        a.Estado == true)
                    .OrderByDescending(a =>
                        a.FechaApertura)
                    .FirstOrDefaultAsync();


            if (apertura == null)
            {
                throw new Exception(
                    "No existe una caja abierta. " +
                    "Debe realizar una apertura de caja antes de registrar un egreso.");
            }


            return apertura.IdAperturaCaja;
        }


        // BUSCAR O CREAR TIPO DE EGRESO
        private async Task<int>
            ObtenerTipoEgresoAsync(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception(
                    "Ingrese el tipo de egreso.");
            }


            nombre = nombre.Trim();


            await using var contexto =
                new NkCollectionContext(_options);


            // BUSCAR SIN IMPORTAR MAYÚSCULAS
            var tipo =
                await contexto.TipoEgresos
                    .FirstOrDefaultAsync(t =>
                        EF.Functions.ILike(
                            t.Nombre,
                            nombre));


            // SI YA EXISTE
            if (tipo != null)
            {
                if (tipo.Estado != true)
                {
                    tipo.Estado = true;

                    await contexto.SaveChangesAsync();
                }

                return tipo.IdTipoEgreso;
            }


            // SI NO EXISTE, CREARLO
            var nuevoTipo =
                new TipoEgreso
                {
                    Nombre = nombre,
                    Descripcion = null,
                    Estado = true
                };


            contexto.TipoEgresos.Add(
                nuevoTipo);


            await contexto.SaveChangesAsync();


            return nuevoTipo.IdTipoEgreso;
        }

        
        // LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            txtbox_tipo_egreso.Clear();

            txtbox_responsable.Clear();

            txtbox_monto.Clear();

            txtbox_tipo_egreso.Focus();
        }
    }
}