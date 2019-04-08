using Ministerio.Interfaces;
using Ministerio.Modals;
using Ministerio.Model;
using Ministerio.Servicio;
using Ministerio.Sqlite.Entidades;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ministerio.ViewModel
{
    public class InformeViewModel : InformeModel
    {
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
        #endregion

        #region Atributos Informe
        private bool _isOcultar = true;
        private bool _isMostrarModal = false;
        private bool _isMostrar = false;
        private bool _isMostrarFlotante = true;
        private string _imagenPay = "ic_play_circle.png";
        private string _imagenPause = "ic_pause_circle.png";
        private string _ImagenStop = "ic_stop.png";
        private bool pausado = false;
        private Color _fondoAtras = Color.White;
        private string _fondoOpacity = "1";
        private Frame _informeModal = null;
        #endregion

        #region Propiedades Informe
        public bool IsMostrarFlotante
        {
            get { return _isMostrarFlotante; }
            set
            {
                _isMostrarFlotante = value;
                OnPropertyChanged();
            }
        }
        public Frame InformeModal
        {
            get { return _informeModal; }
            set
            {
                _informeModal = value;
                OnPropertyChanged();
            }
        }
        public Color FondoAtras
        {
            get { return _fondoAtras; }
            set
            {
                _fondoAtras = value;
                OnPropertyChanged();
            }
        }
        public string FondoOpacity
        {
            get { return _fondoOpacity; }
            set
            {
                _fondoOpacity = value;
                OnPropertyChanged();
            }
        }
        public bool IsMostrarModal
        {
            get { return _isMostrarModal; }
            set
            {
                _isMostrarModal = value;
                OnPropertyChanged();
            }
        }
        public string ImagenPlay
        {
            get { return _imagenPay; }
            set
            {
                _imagenPay = value;
                OnPropertyChanged();
            }
        }
        public string ImagenPause
        {
            get { return _imagenPause; }
            set
            {
                _imagenPause = value;
                OnPropertyChanged();
            }
        }
        public string ImagenStop
        {
            get { return _ImagenStop; }
            set
            {
                _ImagenStop = value;
                OnPropertyChanged();
            }
        }
        public bool IsOcultar
        {
            get { return _isOcultar; }
            set
            {
                _isOcultar = value;
                OnPropertyChanged();
            }
        }
        public bool IsMostrar
        {
            get { return _isMostrar; }
            set
            {
                _isMostrar = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Instancias
        InformeServicio servicio = new InformeServicio();
        Stopwatch mStopWatch = new Stopwatch();
        #endregion

        #region Metodos
        public ICommand GuardarCommand
        {
            get
            {
                return new Command(async () => await Guardar(), () => !IsLoad);
            }
        }
        private async Task Guardar()
        {
            IsLoad = true;
            if (TiempoBinding == null)
            {
                TiempoBinding = "00:00:00";
            }
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
            servicio.Guardar(oMiInforme);
            ListarRegistro();
            await Task.Delay(500);
            Cancelar();
            //DependencyService.Get<IMessage>().ShortToast("Añadido al Informe");
            IsLoad = false;
        }
        void LimpiarCamposGuardar()
        {
            this.FolletosBinding = "";
            this.TiempoBinding = "";
            this.TratadosBinding = "";
            this.LibrosBinding = "";
            this.RevistasBinding = "";
            this.RevisitasBinding = "";
            this.CursosBiblicosBinding = "";
            this.VideosBinding = "";
        }
        private void ListarRegistro()
        {
            var Informes = servicio.Consultar();
            int oHoras = 0, oMinutos = 0, oSegundos = 0, oFolletos = 0, oRevisitas = 0, oRevistas = 0, oVideos = 0, oLibros = 0, oCursosBiblicos = 0, oTratados = 0;
            string oTiempo = "";
            foreach (Informe item in Informes)
            {
                oHoras += item.Hora;
                oMinutos += item.Minutos;
                oSegundos += item.Segundos;
                oTiempo = (oHoras + ":" + oMinutos + ":" + oSegundos);
                oFolletos += item.Folletos;
                oRevisitas += item.Revisitas;
                oRevistas += item.Revistas;
                oVideos += item.Videos;
                oLibros += item.Libros;
                oCursosBiblicos += item.CursosBiblicos;
                oTratados += item.TratadosArticulos;
            }
            Tiempo = (oTiempo == "" ? "00:00:00" : oTiempo);
            Folletos = oFolletos;
            Revistas = oRevistas;
            Revisitas = oRevisitas;
            Libros = oLibros;
            Videos = oVideos;
            Tratados = oTratados;
            CursosBiblicos = oCursosBiblicos;
            Publicaciones = (Folletos + Revistas + Libros + Tratados);
        }
        public ICommand PlayCommand
        {
            get
            {
                return new Command(Play, () => !IsLoad);
            }
        }
        public ICommand PausarCommand
        {
            get
            {
                return new Command(Pausar, () => !IsLoad);
            }
        }
        public ICommand StopCommand
        {
            get
            {
                return new Command(Detener, () => !IsLoad);
            }
        }
        public ICommand CancelarCommand
        {
            get
            {
                return new Command(Cancelar, () => !IsLoad);
            }
        }
        public ICommand AddInformeCommand
        {
            get
            {
                return new Command(AddInforme, () => !IsLoad);
            }
        }
        private void AddInforme()
        {
            IsMostrarModal = true;
            IsMostrarFlotante = false;
            FondoAtras = Color.Gray;
            FondoOpacity = "0.7";
            InformeModal = new InformeModalPage().CargarModalInforme();
        }
        private void Play()
        {
            IsOcultar = false;
            IsMostrar = true;
            if (!pausado)
            {
                TiempoInicial = DateTime.Now.ToString("HH:mm:ss");
            }
            mStopWatch.Start();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //if (!IsOcultar)
                //{
                //    mStopWatch.Start();
                //    OTiempo = string.Format("{0:hh\\:mm\\:ss}", mStopWatch.Elapsed);
                //}
                OTiempo = string.Format("{0:hh\\:mm\\:ss}", mStopWatch.Elapsed);
                return mStopWatch.IsRunning;
            });
        }
        private void Pausar()
        {
            mStopWatch.Stop();
            OTiempo = string.Format("{0:hh\\:mm\\:ss}", mStopWatch.Elapsed);
            IsOcultar = true;
            IsMostrar = false;
            pausado = true;
        }
        private void Detener()
        {
            mStopWatch.Stop();
            mStopWatch.Reset();
            IsOcultar = true;
            IsMostrar = false;
            if (OTiempo != "00:00:00")
            {
                Horas = Convert.ToInt32(OTiempo.Split(':')[0].ToString());
                Minutos = Convert.ToInt32(OTiempo.Split(':')[1].ToString());
                Segundos = Convert.ToInt32(OTiempo.Split(':')[2].ToString());
                if (Segundos > 60)
                {
                    Minutos += Segundos / 60;
                    Segundos = Segundos % 60;
                    if (Minutos > 60)
                    {
                        Horas += Minutos / 60;
                        Minutos = Minutos % 60;
                    }
                }
                IsMostrarModal = true;
                IsMostrarFlotante = false;
                FondoAtras = Color.Gray;
                FondoOpacity = "0.7";
                TiempoBinding = (Horas + ":" + Minutos + ":" + Segundos);
                InformeModal = new InformeModalPage().CargarModalInforme();
                OTiempo = "00:00:00";
                TiempoInicial = "";
            }
        }
        private void Cancelar()
        {
            IsMostrarModal = false;
            IsMostrarFlotante = true;
            FondoAtras = new Color();
            FondoOpacity = "1";
            LimpiarCamposGuardar();
        }
        #endregion

        
        //DependencyService.Get<IMessage>().LongToast(ex.Message);
        #region Constructor
        public InformeViewModel()
        {
            ListarRegistro();
            MainViewModel.GetInstance().InformeAlls = new InformeAllViewModel();
        }
        #endregion
    }
}
