using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ministerio.ViewModel
{
    public class MainViewModel
    {
        public InformeViewModel InformeView { get; set; }
        public InformeAllViewModel InformeAlls { get; set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public MainViewModel()
        {
            /*InformeView = new InformeViewModel()*/
            ;
            instance = this;
            this.LoadMenu();
        }

        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("ic_play_circle.png", "Informe", "InformePage"),
                new MenuItemViewModel("ic_stop.png", "Exit", "LoginPage")
            };
        }

        static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
