using Ministerio.Servicio;
using Ministerio.Sqlite.Entidades;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Ministerio.ViewModel
{
    public class InformeAllViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public InformeAllViewModel()
        {
            var infomes = new List<Informe>();
            foreach (var item in new InformeServicio().Consultar())
            {
                infomes.Add(item);
            }
            MyItemsSource = infomes;

            //MyCommand = new Command(() =>
            //{
            //    Debug.WriteLine("Position selected.");
            //});
        }

        public List<Informe> _myItemsSource;
        public List<Informe> MyItemsSource
        {            
            get { return _myItemsSource; }
            set
            {
                _myItemsSource = value;
                OnPropertyChanged();
            }
        }

        public Command MyCommand { protected set; get; }

        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }
    }
}
