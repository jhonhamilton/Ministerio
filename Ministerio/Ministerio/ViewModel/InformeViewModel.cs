using Ministerio.Model;
using Ministerio.Servicio;
using Ministerio.Sqlite.Entidades;
using Ministerio.View.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ministerio.ViewModel
{
    public class InformeViewModel : InformeModel
    {
        #region Atributos Modal
        private string _tiempoBinding = "00:00:00";
        private string _revistasBinding = "";
        private string _folletosBinding = "";
        private string _librosBinding = "";
        private string _tratadosBinding = "";
        private string _videosBinding = "";
        private string _revisitasBinding = "";
        private string _cursosBiblicosBinding = "";
        private MiInforme _miInforme = new MiInforme();
        #endregion

        #region Propiedades Modal
        public MiInforme MiInforme
        {
            get { return _miInforme; }
            set
            {
                _miInforme = value;
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
        private TableView _informeModal = null;
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
        public TableView InformeModal
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
        Stopwatch mStopWatch = new Stopwatch();
        #endregion

        #region Metodos
        void LimpiarCamposGuardar()
        {
            this.FolletosBinding = "";
            //this.TiempoBinding = "";
            this.TiempoBinding = "00:00:00";
            this.TratadosBinding = "";
            this.LibrosBinding = "";
            this.RevistasBinding = "";
            this.RevisitasBinding = "";
            this.CursosBiblicosBinding = "";
            this.VideosBinding = "";
        }
        public void ListarRegistro()
        {
            var Informes = new InformeServicio().Consultar();
            //var Informes = new InformeRepositorio().ObtenerTodosInformes();
            int oHoras = 0, oMinutos = 0, oSegundos = 0, oFolletos = 0, oRevisitas = 0, oRevistas = 0, oVideos = 0, oLibros = 0, oCursosBiblicos = 0, oTratados = 0;
            string oTiempo = "";
            foreach (Informe item in Informes)
            {
                oHoras += item.Hora;
                oMinutos += item.Minutos;
                oSegundos += item.Segundos;                
                oFolletos += item.Folletos;
                oRevisitas += item.Revisitas;
                oRevistas += item.Revistas;
                oVideos += item.Videos;
                oLibros += item.Libros;
                oCursosBiblicos += item.CursosBiblicos;
                oTratados += item.TratadosArticulos;
            }
            oTiempo = (oHoras + ":" + oMinutos + ":" + oSegundos);
            MiInforme = new MiInforme((oTiempo == "" ? "00:00:00" : oTiempo), oRevisitas, oVideos, 
                (oFolletos + oRevistas + oLibros + oTratados), oCursosBiblicos);
            MainViewModel.GetInstance().InformeAlls = null;
            MainViewModel.GetInstance().InformeAlls = new InformeAllViewModel();
        }
        public ICommand CompartirCommand
        {
            get
            {
                return new Command(Compartir, () => !IsLoad);
            }
        }
        private async void Compartir()
        {
            string miInforme = "Envio mi Informe \n\n";
            miInforme += "Horas: " + MiInforme.Tiempo.Split(':')[0].ToString() + " \n";
            miInforme += "Publicaciones: " + MiInforme.Publicaciones.ToString() + " \n";
            miInforme += "Videos: " + MiInforme.Videos.ToString() + " \n";
            miInforme += "Revisitas: " + MiInforme.Revisitas.ToString() + " \n";
            miInforme += "Cursos Biblicos: " + MiInforme.CursosBiblicos.ToString();
            await Share.RequestAsync(new ShareTextRequest
            {
                Subject = "Informe - Ministerio",                
                Text = miInforme,
                Title = "Ministerio!"
            });
        }
        public ICommand PlayCommand
        {
            get
            {
                return new Command(Play, () => !IsLoad);
            }
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
                OTiempo = string.Format("{0:hh\\:mm\\:ss}", mStopWatch.Elapsed);
                return mStopWatch.IsRunning;
            });
        }
        public ICommand PausarCommand
        {
            get
            {
                return new Command(Pausar, () => !IsLoad);
            }
        }
        private void Pausar()
        {
            mStopWatch.Stop();
            OTiempo = string.Format("{0:hh\\:mm\\:ss}", mStopWatch.Elapsed);
            IsOcultar = true;
            IsMostrar = false;
            pausado = true;
        }
        public ICommand StopCommand
        {
            get
            {
                return new Command(Detener, () => !IsLoad);
            }
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
                TiempoBinding = (Horas + ":" + Minutos + ":" + Segundos);
                AddInforme();
                OTiempo = "00:00:00";
                TiempoInicial = "";
            }
        }
        public ICommand CancelarCommand
        {
            get
            {
                return new Command(Cancelar, () => !IsLoad);
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
        public ICommand AddInformeCommand
        {
            get
            {
                return new Command(AddInforme, () => !IsLoad);
            }
        }
        private void AddInforme()
        {
            MainViewModel.GetInstance().Popups = new AddInformeViewModel(0, DateTime.Now, this.TiempoBinding, this.RevisitasBinding, 
                this.FolletosBinding, this.LibrosBinding, this.TratadosBinding, this.VideosBinding, 
                this.RevistasBinding, this.CursosBiblicosBinding);
            var addInforme = new AddInformeView();
            addInforme.CallbackEvent += (object sender, object e) => ListarRegistro();
            addInforme.CancelCallbackEvent += (object sender, object e) => LimpiarCamposGuardar();
            PopupNavigation.Instance.PushAsync(addInforme, true);
        }
        #endregion

        #region Constructor
        public InformeViewModel()
        {
            MiInforme = new MiInforme("00:00:00", 0, 0, 0, 0);
            ListarRegistro();            
        }
        #endregion
    }
}
