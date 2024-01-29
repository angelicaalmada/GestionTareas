using GestionTareas.Datos;
using GestionTareas.Modelo;
using GestionTareas.Vista;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionTareas.ViewModel
{
    public class VMprincipal: BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        ObservableCollection<TareasModel> _Listatareas;
        TareasModel _TareaSeleccionada;
        #endregion
        #region CONSTRUCTOR
        public VMprincipal(INavigation navigation)
        {
            Navigation = navigation;
            Mostrartarea();
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set {SetValue(ref _Texto, value);}
        }
        public ObservableCollection<TareasModel> Listatareas
        {
            get { return _Listatareas; }
            set
            {
                SetValue(ref _Listatareas, value);
                OnpropertyChanged();
            }
        }
        public TareasModel TareaSeleccionada
        {
            get { return _TareaSeleccionada; }
            set
            {
                if (_TareaSeleccionada != value)
                {
                    _TareaSeleccionada = value;
                }
            }
        }
        #endregion
        #region PROCESOS
        public async Task Mostrartarea()
        {
            var funcion = new Dtareas();
            Listatareas = await funcion.MostrarTareas();
        }
        public async Task Iraregistro()
        {
            await Navigation.PushAsync(new MenuAgregar());
        }
        public void ProcesoSimple()
        {

        }
        public async Task AbrirVistaModificar()
        {
            await Navigation.PushAsync(new Modificar(TareaSeleccionada));
        }
        #endregion
        #region COMANDOS
        public ICommand Iraregistrocommand => new Command(async () => await Iraregistro());
        public ICommand AbrirVistaModificarcommand => new Command(async () => await AbrirVistaModificar());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
