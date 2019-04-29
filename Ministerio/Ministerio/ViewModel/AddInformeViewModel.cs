using Ministerio.Interfaces;
using Ministerio.Servicio;
using Ministerio.Sqlite.Entidades;
using Ministerio.View.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ministerio.ViewModel
{
    public class AddInformeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Atributos Modal
        private string _tiempoBinding;
        private string _revistasBinding = "";
        private string _folletosBinding = "";
        private string _librosBinding = "";
        private string _tratadosBinding = "";
        private string _videosBinding = "";
        private string _revisitasBinding = "";
        private string _cursosBiblicosBinding = "";
        #endregion
        #region Propiedades Modal
        public string TiempoBinding
        {
            get { return _tiempoBinding; }
            set
            {
                _tiempoBinding = value;
                OnPropertyChanged();
            }
        }
        public string RevistasBinding
        {
            get { return _revistasBinding; }
            set
            {
                _revistasBinding = value;
                OnPropertyChanged();
            }
        }
        public string FolletosBinding
        {
            get { return _folletosBinding; }
            set
            {
                _folletosBinding = value;
                OnPropertyChanged();
            }
        }
        public string LibrosBinding
        {
            get { return _librosBinding; }
            set
            {
                _librosBinding = value;
                OnPropertyChanged();
            }
        }
        public string TratadosBinding
        {
            get { return _tratadosBinding; }
            set
            {
                _tratadosBinding = value;
                OnPropertyChanged();
            }
        }
        public string VideosBinding
        {
            get { return _videosBinding; }
            set
            {
                _videosBinding = value;
                OnPropertyChanged();
            }
        }
        public string RevisitasBinding
        {
            get { return _revisitasBinding; }
            set
            {
                _revisitasBinding = value;
                OnPropertyChanged();
            }
        }
        public string CursosBiblicosBinding
        {
            get { return _cursosBiblicosBinding; }
            set
            {
                _cursosBiblicosBinding = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand
        {
            get
            {
                return new Command(Guardar);
                
            }
        }
        public ICommand CancelarCommand
        {
            get
            {
                return new Command(Cancelar);
            }
        }
        //public ICommand RestRevistasCommand
        //{
        //    get
        //    {
        //        return new Command(RestRevistas);
        //    }
        //}
        public ICommand ConteoRevistasCommand
        {
            get
            {
                return new Command<string>((x) => ConteoRevistas(x));
            }
        }
        //public ICommand RestFolletosCommand
        //{
        //    get
        //    {
        //        return new Command(RestFolletos);
        //    }
        //}
        //public ICommand SumFolletosCommand
        //{
        //    get
        //    {
        //        return Command(SumFolletos);
        //    }
        //}
        #endregion
        //private void RestRevistas(string parametro)
        //{
        //    if (parametro == "R")
        //    {

        //    }
        //    else
        //    {

        //    }
        //    if (Convert.ToInt32(this.RevistasBinding) > 0)
        //    {
        //        this.RevistasBinding = (Convert.ToInt32(this.RevistasBinding) - 1).ToString();
        //    }
        //}
        //private void ConteoRevistas(string parametro)
        private void ConteoRevistas(string parametro)
        {
            if (this.RevistasBinding == null || this.RevistasBinding == "")
            {
                this.RevistasBinding = "0";
            }
            if (parametro == "R")
            {
                if (Convert.ToInt32(this.RevistasBinding) > 0)
                {
                    this.RevistasBinding = (Convert.ToInt32(this.RevistasBinding) - 1).ToString();
                }
            }
            else
            {
                this.RevistasBinding = (Convert.ToInt32(this.RevistasBinding) + 1).ToString();
            }
        }
        private async void Cancelar()
        {
            this.FolletosBinding = "";
            this.TiempoBinding = "";
            this.TratadosBinding = "";
            this.LibrosBinding = "";
            this.RevistasBinding = "";
            this.RevisitasBinding = "";
            this.CursosBiblicosBinding = "";
            this.VideosBinding = "";
            await PopupNavigation.Instance.PopAllAsync();
        }
        private async void Guardar()
        {
            var oMiInforme = new Informe
            {
                Hora = Convert.ToInt32(this.TiempoBinding.Split(':')[0]),
                Minutos = Convert.ToInt32(this.TiempoBinding.Split(':')[1]),
                Segundos = Convert.ToInt32(this.TiempoBinding.Split(':')[2]),
                Libros = (this.LibrosBinding != "" ? Convert.ToInt32(this.LibrosBinding.ToString()) : 0),
                Revisitas = (this.RevisitasBinding != "" ? Convert.ToInt32(this.RevisitasBinding) : 0),
                Revistas = (this.RevistasBinding != "" ? Convert.ToInt32(this.RevistasBinding) : 0),
                CursosBiblicos = (this.CursosBiblicosBinding != "" ? Convert.ToInt32(this.CursosBiblicosBinding) : 0),
                Videos = (this.VideosBinding != "" ? Convert.ToInt32(this.VideosBinding) : 0),
                TratadosArticulos = (this.TratadosBinding != "" ? Convert.ToInt32(this.TratadosBinding) : 0),
                Folletos = (this.FolletosBinding != "" ? Convert.ToInt32(this.FolletosBinding) : 0),
                Fecha = DateTime.Now
            };
            new InformeServicio().Guardar(oMiInforme);
            await PopupNavigation.Instance.PopAllAsync();
        }
        public AddInformeViewModel(string tiempo, string revisitas, string folletos, string libros, string tratados, string videos, string revistas, string cursos)
        {
            this.TiempoBinding = tiempo;
            this.RevisitasBinding = revisitas;
            this.FolletosBinding = folletos;
            this.LibrosBinding = libros;
            this.TratadosBinding = tratados;
            this.VideosBinding = videos;
            this.RevistasBinding = revistas;
            this.CursosBiblicosBinding = cursos;
            //this.servicio = new InformeServicio();
        }

        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }
    }
}
