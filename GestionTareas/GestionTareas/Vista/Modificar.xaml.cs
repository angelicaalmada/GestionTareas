using GestionTareas.Modelo;
using GestionTareas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionTareas.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modificar : ContentPage
    {
        public Modificar(TareasModel tareasModel)
        {
            InitializeComponent();
            BindingContext = new VMmodificar(tareasModel , Navigation);
        }
    }
}