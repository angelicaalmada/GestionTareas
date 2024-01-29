using GestionTareas.Vista;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionTareas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new PaginaPrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
