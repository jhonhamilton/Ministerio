using Ministerio.Servicio;
using Ministerio.Sqlite.Entidades;
using Rg.Plugins.Popup.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ministerio.ViewModel
{
    public class AddInformeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Atributos Modal
        private int _Id = 0;
        private DateTime _fecha;
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
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                _fecha = value;
                OnPropertyChanged();
            }
        }
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
        public ICommand ConteoRevistasCommand
        {
            get
            {
                return new Command<string>((x) => Conteos(x, "revistas"));
            }
        }
        public ICommand ConteoFolletosCommand
        {
            get
            {
                return new Command<string>((x) => Conteos(x, "folletos"));
            }
        }
        public ICommand ConteoLibrosCommand
        {
            get
            {
                return new Command<string>((x) => Conteos(x, "libros"));
            }
        }
        public ICommand ConteoTratadosCommand
        {
            get
            {
                return new Command<string>((x) => Conteos(x, "tratados"));
            }
        }
        public ICommand ConteoVideosCommand
        {
            get
            {
                return new Command<string>((x) => Conteos(x, "videos"));
            }
        }
        public ICommand ConteoRevisitasCommand
        {
            get
            {
                return new Command<string>((x) => Conteos(x, "revisitas"));
            }
        }
        public ICommand ConteoCursosBiblicosCommand
        {
            get
            {
                return new Command<string>((x) => Conteos(x, "cursos"));
            }
        }
        #endregion
        private void Conteos(string parametro, string tipo)
        {
            if (tipo.ToUpper() == "REVISTAS")
            {
                ConteoRevistas(parametro);
            }
            else if(tipo.ToUpper() == "FOLLETOS")
            {
                ConteoFolletos(parametro);
            }
            else if (tipo.ToUpper() == "LIBROS")
            {
                ConteoLibros(parametro);
            }
            else if (tipo.ToUpper() == "TRATADOS")
            {
                ConteoTratados(parametro);
            }
            else if (tipo.ToUpper() == "VIDEOS")
            {
                ConteoVideos(parametro);
            }
            else if (tipo.ToUpper() == "REVISITAS")
            {
                ConteoRevisitas(parametro);
            }
            else
            {
                ConteoCursos(parametro);
            }
        }
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
                else
                {
                    this.RevistasBinding = "";
                }
            }
            else
            {
                this.RevistasBinding = (Convert.ToInt32(this.RevistasBinding) + 1).ToString();
            }
        }
        private void ConteoFolletos(string parametro)
        {
            if (this.FolletosBinding == null || this.FolletosBinding == "")
            {
                this.FolletosBinding = "0";
            }
            if (parametro == "R")
            {
                if (Convert.ToInt32(this.FolletosBinding) > 0)
                {
                    this.FolletosBinding = (Convert.ToInt32(this.FolletosBinding) - 1).ToString();
                }
                else
                {
                    this.FolletosBinding = "";
                }
            }
            else
            {
                this.FolletosBinding = (Convert.ToInt32(this.FolletosBinding) + 1).ToString();
            }
        }
        private void ConteoLibros(string parametro)
        {
            if (this.LibrosBinding == null || this.LibrosBinding == "")
            {
                this.LibrosBinding = "0";
            }
            if (parametro == "R")
            {
                if (Convert.ToInt32(this.LibrosBinding) > 0)
                {
                    this.LibrosBinding = (Convert.ToInt32(this.LibrosBinding) - 1).ToString();
                }
                else
                {
                    this.LibrosBinding = "";
                }
            }
            else
            {
                this.LibrosBinding = (Convert.ToInt32(this.LibrosBinding) + 1).ToString();
            }
        }
        private void ConteoTratados(string parametro)
        {
            if (this.TratadosBinding == null || this.TratadosBinding == "")
            {
                this.TratadosBinding = "0";
            }
            if (parametro == "R")
            {
                if (Convert.ToInt32(this.TratadosBinding) > 0)
                {
                    this.TratadosBinding = (Convert.ToInt32(this.TratadosBinding) - 1).ToString();
                }
                else
                {
                    this.TratadosBinding = "";
                }
            }
            else
            {
                this.TratadosBinding = (Convert.ToInt32(this.TratadosBinding) + 1).ToString();
            }
        }
        private void ConteoVideos(string parametro)
        {
            if (this.VideosBinding == null || this.VideosBinding == "")
            {
                this.VideosBinding = "0";
            }
            if (parametro == "R")
            {
                if (Convert.ToInt32(this.VideosBinding) > 0)
                {
                    this.VideosBinding = (Convert.ToInt32(this.VideosBinding) - 1).ToString();
                }
                else
                {
                    this.VideosBinding = "";
                }
            }
            else
            {
                this.VideosBinding = (Convert.ToInt32(this.VideosBinding) + 1).ToString();
            }
        }
        private void ConteoRevisitas(string parametro)
        {
            if (this.RevisitasBinding == null || this.RevisitasBinding == "")
            {
                this.RevisitasBinding = "0";
            }
            if (parametro == "R")
            {
                if (Convert.ToInt32(this.RevisitasBinding) > 0)
                {
                    this.RevisitasBinding = (Convert.ToInt32(this.RevisitasBinding) - 1).ToString();
                }
                else
                {
                    this.RevisitasBinding = "";
                }
            }
            else
            {
                this.RevisitasBinding = (Convert.ToInt32(this.RevisitasBinding) + 1).ToString();
            }
        }
        private void ConteoCursos(string parametro)
        {
            if (this.CursosBiblicosBinding == null || this.CursosBiblicosBinding == "")
            {
                this.CursosBiblicosBinding = "0";
            }
            if (parametro == "R")
            {
                if (Convert.ToInt32(this.CursosBiblicosBinding) > 0)
                {
                    this.CursosBiblicosBinding = (Convert.ToInt32(this.CursosBiblicosBinding) - 1).ToString();
                }
                else
                {
                    this.CursosBiblicosBinding = "";
                }
            }
            else
            {
                this.CursosBiblicosBinding = (Convert.ToInt32(this.CursosBiblicosBinding) + 1).ToString();
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
            //await PopupNavigation.Instance.PopAllAsync();
            await PopupNavigation.Instance.PopAsync();
        }
        private async void Guardar()
        {
            var oMiInforme = new Informe
            {
                Id = this.Id,
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
                Fecha = (this.Id > 0 ? this.Fecha : DateTime.Now)
            };
            if (oMiInforme.Id > 0)
            {
                new InformeServicio().Modificar(oMiInforme);
                //new InformeRepositorio().UpdateInforme(oMiInforme);
            }
            else
            {
                new InformeServicio().Guardar(oMiInforme);
                //new InformeRepositorio().AgregarInforme(oMiInforme);
            }
            //await PopupNavigation.Instance.PopAllAsync();
            await PopupNavigation.Instance.PopAsync();
        }
        public AddInformeViewModel(int id, DateTime fecha, string tiempo, string revisitas, string folletos, string libros, string tratados, string videos, string revistas, string cursos)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.TiempoBinding = tiempo;
            this.RevisitasBinding = (revisitas != "" && Convert.ToInt32(revisitas) > 0 ? revisitas : "");
            this.FolletosBinding = (folletos != "" && Convert.ToInt32(folletos) > 0 ? folletos : "");
            this.LibrosBinding = (libros != "" && Convert.ToInt32(libros) > 0 ? libros: "");
            this.TratadosBinding = (tratados != "" && Convert.ToInt32(tratados) > 0 ? tratados : "");
            this.VideosBinding = (videos != "" && Convert.ToInt32(videos) > 0 ? videos : "");
            this.RevistasBinding = (revistas != "" && Convert.ToInt32(revistas) > 0 ? revistas : "");
            this.CursosBiblicosBinding = (cursos != "" && Convert.ToInt32(cursos) > 0 ? cursos : "");
        }
        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }
    }
}
