using System;
using Demo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Demo
{
    public partial class App : Application
    {
        public App()
        {
            //instatiate a new appVM - don't use dependency injection as it doesn't exist yet
            BindingContext = new AppVM();

            //init the XAML
            InitializeComponent();

            //Set the main page
            MainPage = new InteractionPage();
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
