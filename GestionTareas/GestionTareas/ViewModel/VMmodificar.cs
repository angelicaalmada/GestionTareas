using GestionTareas.Datos;
using GestionTareas.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionTareas.ViewModel
{
    public class VMmodificar: BaseViewModel
    {
        #region VARIABLES
        string _nombre;
        string _descripcion;
        string _estatus;
        TareasModel _Tareaseleccionada;
        #endregion
        #region CONSTRUCTOR
        public VMmodificar(TareasModel tareaSeleccion, INavigation navigation)
        {
            Navigation = navigation;
            _nombre = tareaSeleccion.Nombre.ToString();
            _descripcion = tareaSeleccion.Descripcion.ToString();
            _estatus = tareaSeleccion.Status.ToString();
            _Tareaseleccionada = tareaSeleccion;
        }

        public VMmodificar(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Nombre
        {
            get { return _nombre; }
            set { SetValue(ref _nombre, value); }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetValue(ref _descripcion, value); }
        }
        public string Estatus
        {
            get { return _estatus; }
            set { SetValue(ref _estatus, value); }
        }
        public TareasModel TareaSeleccionada
        {
            get { return _Tareaseleccionada; }
            set { SetValue(ref _Tareaseleccionada, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ModificarTareas()
        {
            var funcion = new Dtareas();
            TareaSeleccionada.Nombre = Nombre;
            TareaSeleccionada.Descripcion = Descripcion;
            TareaSeleccionada.Status = Estatus;
            await funcion.ModificarTareas(TareaSeleccionada);
            await DisplayAlert("Modificada", $"La tarea  {TareaSeleccionada.Nombre} ah sido modificada", "OK");
            await Volver();
        }
        public async Task EliminarTareas()
        {
            var funcion = new Dtareas();
            await funcion.BorrarTarea(TareaSeleccionada.IdTareas);
            await DisplayAlert("Eliminada", $"La tarea  {TareaSeleccionada.Nombre} ah sido eliminado", "OK");
            await Volver();
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand ModificarTareascommand => new Command(async () => await ModificarTareas());
        public ICommand EliminarTareascommand => new Command(async () => await EliminarTareas());
        #endregion
    }
}
