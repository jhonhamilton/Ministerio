using Ministerio.View;
using Ministerio.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Ministerio
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.InformeView = new InformeViewModel();
            MainPage = new MasterPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
