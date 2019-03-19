using Ministerio.View;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ministerio.ViewModel
{
    public class MenuItemViewModel
    {
        public string Icon { get; set; }
        public string Titulo { get; set; }
        public string NombrePagina { get; set; }
        public MenuItemViewModel()
        {

        }
        public MenuItemViewModel(string icon, string titulo, string nombrePagina)
        {
            this.Icon = icon;
            this.Titulo = titulo;
            this.NombrePagina = nombrePagina;
        }

        public ICommand GotoCommand
        {
            get
            {
                return new Command(Goto);
            }
        }

        private void Goto(object obj)
        {
            if (this.NombrePagina == "LoginPage")
            {
                MainViewModel.GetInstance().InformeView = new InformeViewModel();
                Application.Current.MainPage = new NavigationPage(new InformePage());
            }
        }
    }
}
