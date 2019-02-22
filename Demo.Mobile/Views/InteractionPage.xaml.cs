using System;
using System.Collections.Generic;
using CommonServiceLocator;
using Pazz.Mobile.ViewModels;
using Xamarin.Forms;

namespace Pazz.Mobile.Views
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
