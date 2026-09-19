using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;
using NK_COLLECTION.Negocios.Catalogos;

namespace NK_COLLECTION.Presentacion.Catalogos
{
    public partial class Frm_proveedores : Form
    {
        private readonly Proveedor_Service _servicio = new(DbConfiguracion.Options);
        private int _idEditar;
        public Frm_proveedores(){ InitializeComponent(); Load += async (_,_) => await CargarAsync(); btn_mostrar.Click += btn_mostrar_Click; btn_guardar.Click += btn_guardar_Click; btn_limpiar.Click += btn_limpiar_Click; btn_guardar_nuevo.Click += GuardarNuevo; btn_cancelar_nuevo.Click += (_,_)=>LimpiarNuevo(); btn_guardar_editar.Click += GuardarEditar; btn_cancelar_editar.Click += (_,_)=>LimpiarEditar(); dgw_proveedores.CellDoubleClick += Seleccionar; dgw_proveedores_editar.CellDoubleClick += Seleccionar; }
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private async void btn_buscar_Click(object sender, EventArgs e){ MostrarPrincipal(await _servicio.BuscarAsync(txtbox_buscarpor.Text)); }
        private async void btn_mostrar_Click(object sender, EventArgs e)=>await CargarAsync();
        private void btn_guardar_Click(object sender, EventArgs e)=>tabControl1.SelectedTab=tabpag_nuevo_proveedor;
        private async void btn_limpiar_Click(object sender, EventArgs e){ txtbox_buscarpor.Clear(); await CargarAsync(); }
        private async void GuardarNuevo(object? s, EventArgs e){ try{ await _servicio.GuardarAsync(txtbox_nombre.Text,txtbox_telefono.Text,txtbox_correo_electronico.Text,txtbox_direccion.Text,txtbox_ruc.Text); MessageBox.Show("Proveedor guardado correctamente."); LimpiarNuevo(); await CargarAsync(); }catch(Exception ex){MessageBox.Show(ex.Message,"Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);} }
        private async void Seleccionar(object? s, DataGridViewCellEventArgs e){ if(e.RowIndex<0||s is not DataGridView g||g.Rows[e.RowIndex].Tag is not int id)return; var p=await _servicio.ObtenerPorIdAsync(id); if(p==null)return; _idEditar=id; txtbox_nombre_editar.Text=p.Nombre; txtbox_telefono_editar.Text=p.Telefono??""; txtbox_correo_electronico_editar.Text=p.Correo??""; txtbox_direccion_editar.Text=p.Direccion??""; txtbox_ruc_editar.Text=p.Ruc??""; tabControl1.SelectedTab=tabPage3; }
        private async void GuardarEditar(object? s, EventArgs e){ try{ if(_idEditar==0)throw new Exception("Seleccione un proveedor para editar."); await _servicio.EditarAsync(_idEditar,txtbox_nombre_editar.Text,txtbox_telefono_editar.Text,txtbox_correo_electronico_editar.Text,txtbox_direccion_editar.Text,txtbox_ruc_editar.Text); MessageBox.Show("Proveedor actualizado correctamente."); LimpiarEditar(); await CargarAsync(); }catch(Exception ex){MessageBox.Show(ex.Message,"Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);} }
        private async Task CargarAsync(){var x=await _servicio.ListarAsync(); MostrarPrincipal(x); MostrarResumen(dgw_proveedores_nuevo,x); MostrarResumen(dgw_proveedores_editar,x);}
        private void MostrarPrincipal(List<Proveedor> xs){dgw_proveedores.Rows.Clear();foreach(var p in xs){int i=dgw_proveedores.Rows.Add(p.IdProveedor,p.Nombre,p.Telefono,p.Ruc,p.Direccion,p.Correo,p.Estado==true?"Activo":"Inactivo");dgw_proveedores.Rows[i].Tag=p.IdProveedor;}}
        private static void MostrarResumen(DataGridView g,List<Proveedor> xs){g.Rows.Clear();foreach(var p in xs){int i=g.Rows.Add(p.Nombre,p.Direccion,p.Telefono,p.Estado==true?"Activo":"Inactivo");g.Rows[i].Tag=p.IdProveedor;}}
        private void LimpiarNuevo(){txtbox_nombre.Clear();txtbox_telefono.Clear();txtbox_correo_electronico.Clear();txtbox_direccion.Clear();txtbox_ruc.Clear();}
        private void LimpiarEditar(){_idEditar=0;txtbox_nombre_editar.Clear();txtbox_telefono_editar.Clear();txtbox_correo_electronico_editar.Clear();txtbox_direccion_editar.Clear();txtbox_ruc_editar.Clear();}
    }
}
