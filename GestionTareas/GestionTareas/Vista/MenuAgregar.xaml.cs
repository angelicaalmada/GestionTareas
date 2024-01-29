﻿using GestionTareas.ViewModel;
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
    public partial class MenuAgregar : ContentPage
    {
        public MenuAgregar()
        {
            InitializeComponent();
            BindingContext = new VMagregarTarea(Navigation);
        }
    }
}