using System;
using System.Collections.Generic;
using CommonServiceLocator;
using Demo.ViewModels;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class InteractionPage : ContentPage
    {
        public InteractionPage()
        {
            BindingContext = ServiceLocator.Current.GetInstance(typeof(InteractionPageVM));
            InitializeComponent();
        }
    }
}
