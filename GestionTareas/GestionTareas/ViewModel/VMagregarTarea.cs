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
    public class VMagregarTarea: BaseViewModel
    {
        #region VARIABLES   
        string _Txtnombre;
        string _Txtdescripcion;
        string _Txtestatus;
        #endregion
        #region CONSTRUCTOR
        public VMagregarTarea(INavigation navigation )
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string TxtNombre
        {
            get { return _Txtnombre; }
            set { SetValue(ref _Txtnombre, value); }
        }
        public string Txtdescripcion
        {
            get { return _Txtdescripcion; }
            set { SetValue(ref _Txtdescripcion, value); }
        }
        public string Txtestatus
        {
            get { return _Txtestatus;}
            set { SetValue(ref _Txtestatus, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Insertar()
        {
            var funcion = new Dtareas();
            var parametros = new TareasModel();
            parametros.Nombre = TxtNombre;
            parametros.Descripcion = Txtdescripcion;
            parametros.Status = Txtestatus;

            await funcion.InsertarTarea(parametros);
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
        public ICommand Insertarcommand => new Command(async () =>
        {
            await Insertar();
        });

        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
