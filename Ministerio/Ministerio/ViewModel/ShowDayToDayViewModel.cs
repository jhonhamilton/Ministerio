using Ministerio.Servicio;
using Ministerio.Sqlite.Entidades;
using Ministerio.Sqlite.Repositorio;
using Ministerio.View.Popups;
using Rg.Plugins.Popup.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ministerio.ViewModel
{
    public class ShowDayToDayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }

        #region Atributos Modal
        private int _Id = 0;
        private string _tiempo;
        private string _revistas = "";
        private string _folletos = "";
        private string _libros = "";
        private string _tratados = "";
        private string _videos = "";
        private string _revisitas = "";
        private string _cursosBiblicos = "";
        private ObservableCollection<Informe> _days = new ObservableCollection<Informe>();
        private Informe _selectedDay { get; set; }
        #endregion
        #region Propiedades Modal
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        public Informe SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                if (_selectedDay != value)
                {
                    _selectedDay = value;
                    ShowAddInforme(value.Id, value.Fecha.Month); 
                }
            }
        }
        public ObservableCollection<Informe> Days
        {
            get { return _days; }
            set
            {
                _days = value;
                OnPropertyChanged();
            }
        }
        public string Tiempo
        {
            get { return _tiempo; }
            set
            {
                _tiempo = value;
                OnPropertyChanged();
            }
        }
        public string Revistas
        {
            get { return _revistas; }
            set
            {
                _revistas = value;
                OnPropertyChanged();
            }
        }
        public string Folletos
        {
            get { return _folletos; }
            set
            {
                _folletos = value;
                OnPropertyChanged();
            }
        }
        public string Libros
        {
            get { return _libros; }
            set
            {
                _libros = value;
                OnPropertyChanged();
            }
        }
        public string Tratados
        {
            get { return _tratados; }
            set
            {
                _tratados = value;
                OnPropertyChanged();
            }
        }
        public string Videos
        {
            get { return _videos; }
            set
            {
                _videos = value;
                OnPropertyChanged();
            }
        }
        public string Revisitas
        {
            get { return _revisitas; }
            set
            {
                _revisitas = value;
                OnPropertyChanged();
            }
        }
        public string CursosBiblicos
        {
            get { return _cursosBiblicos; }
            set
            {
                _cursosBiblicos = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private void ShowAddInforme(int Id, int mes)
        {
            var oInforme = Days.Where(i => i.Id == Id).FirstOrDefault();
            string oTiempo = oInforme.Hora.ToString() + ":" + oInforme.Minutos.ToString() + ":" + oInforme.Segundos.ToString();
            MainViewModel.GetInstance().Popups = new AddInformeViewModel(oInforme.Id, oInforme.Fecha, oTiempo, oInforme.Revisitas.ToString(), oInforme.Folletos.ToString(),
                oInforme.Libros.ToString(), oInforme.TratadosArticulos.ToString(), oInforme.Videos.ToString(), oInforme.Revistas.ToString(), oInforme.CursosBiblicos.ToString());
            var addInforme = new AddInformeView();
            addInforme.CallbackEvent += (object sender, object e) => ListarDay(mes);
            PopupNavigation.Instance.PushAsync(addInforme, true);
        }

        private void ListarDay(int mes)
        {
            Days = null;
            Days = new ObservableCollection<Informe>(new InformeServicio().Consultar().Where(m => m.Fecha.Month == mes).OrderByDescending(m => m.Fecha));
            //Days = new ObservableCollection<Informe>(new InformeRepositorio().ObtenerTodosInformes().Where(m => m.Fecha.Month == mes).OrderByDescending(m => m.Fecha));
        }

        public ShowDayToDayViewModel()
        {

        }
        public ShowDayToDayViewModel(string tiempo, string revistas, string folletos, string libros, string tratados, string videos, string revisitas, string cursos)
        {
            this.Tiempo = tiempo;
            this.Revistas = revistas;
            this.Folletos = folletos;
            this.Libros = libros;
            this.Tratados = tratados;
            this.Videos = videos;
            this.Revisitas = revisitas;
            this.CursosBiblicos = cursos;
        }
        public ShowDayToDayViewModel(ObservableCollection<Informe> informes)
        {
            Days = new ObservableCollection<Informe>(informes);
        }
    }
}
