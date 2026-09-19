using NK_COLLECTION.Datos;
using NK_COLLECTION.Datos.Modelos;
using NK_COLLECTION.Negocios.Catalogos;

namespace NK_COLLECTION.Presentacion.Productos
{
    public partial class Frm_categoria : Form
    {
        private readonly Caregoria_Service _servicio = new(DbConfiguracion.Options); private int _idEditar;
        public Frm_categoria(){InitializeComponent();Load+=Frm_categoria_Load;btn_mostrar.Click+=btn_mostrar_Click;btn_guardar.Click+=btn_guardar_Click;btn_buscar.Click+=btn_buscar_Click;btn_limpiar.Click+=btn_limpiar_Click;btn_guardar_nuevo.Click+=GuardarNuevo;btn_cancelar_nuevo.Click+=(_,_)=>LimpiarNuevo();btn_guardar_editar.Click+=GuardarEditar;btn_cancelar_editar.Click+=(_,_)=>LimpiarEditar();btn_inhabilitar_editar.Click+=CambiarEstado;dgw_categoria.CellDoubleClick+=Seleccionar;dgw_categoria_editar.CellDoubleClick+=Seleccionar;}
        private void label2_Click(object sender, EventArgs e){}
        private async void Frm_categoria_Load(object? sender,EventArgs e)=>await CargarAsync();
        private async void btn_mostrar_Click(object sender,EventArgs e)=>await CargarAsync();
        private void btn_guardar_Click(object sender,EventArgs e)=>tabControl1.SelectedTab=tabpag_categoria_nueva;
        private async void btn_buscar_Click(object sender,EventArgs e){var t=Microsoft.VisualBasic.Interaction.InputBox("Nombre de categoría:","Buscar");Mostrar(dgw_categoria,await _servicio.BuscarAsync(t));}
        private async void btn_limpiar_Click(object sender,EventArgs e)=>await CargarAsync();
        private async void GuardarNuevo(object? s,EventArgs e){try{await _servicio.GuardarAsync(txtbox_nombre_categoria.Text,txtbox_descripcion.Text);MessageBox.Show("Categoría guardada.");LimpiarNuevo();await CargarAsync();}catch(Exception ex){MessageBox.Show(ex.Message);}}
        private async void Seleccionar(object? s,DataGridViewCellEventArgs e){if(e.RowIndex<0||s is not DataGridView g||g.Rows[e.RowIndex].Tag is not int id)return;var c=await _servicio.ObtenerPorIdAsync(id);if(c==null)return;_idEditar=id;txtbox_nombre_editar.Text=c.NombreCategoria;txtbox_descripcion_editar.Text=c.Descripcion??"";tabControl1.SelectedTab=tabpag_editar;}
        private async void GuardarEditar(object? s,EventArgs e){try{if(_idEditar==0)throw new Exception("Seleccione una categoría.");await _servicio.EditarAsync(_idEditar,txtbox_nombre_editar.Text,txtbox_descripcion_editar.Text);MessageBox.Show("Categoría actualizada.");await CargarAsync();}catch(Exception ex){MessageBox.Show(ex.Message);}}
        private async void CambiarEstado(object? s,EventArgs e){if(_idEditar==0)return;var c=await _servicio.ObtenerPorIdAsync(_idEditar);if(c==null)return;await _servicio.CambiarEstadoAsync(_idEditar,c.Estado!=true);await CargarAsync();}
        private async Task CargarAsync(){var x=await _servicio.ListarAsync();Mostrar(dgw_categoria,x);Mostrar(dgw_categoria_nueva,x);Mostrar(dgw_categoria_editar,x);}
        private static void Mostrar(DataGridView g,List<Categorium> xs){g.Rows.Clear();foreach(var c in xs){int i=g.Rows.Add(c.IdCategoria,c.NombreCategoria,c.Descripcion,c.Estado==true?"Activo":"Inactivo");g.Rows[i].Tag=c.IdCategoria;}}
        private void LimpiarNuevo(){txtbox_nombre_categoria.Clear();txtbox_descripcion.Clear();}
        private void LimpiarEditar(){_idEditar=0;txtbox_nombre_editar.Clear();txtbox_descripcion_editar.Clear();}
    }
}
