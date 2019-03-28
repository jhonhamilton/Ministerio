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
        private string _TiempoBinding;
        private string _RevistasBinding = "";
        private string _FolletosBinding = "";
        private string _LibrosBinding = "";
        private string _TratadosBinding = "";
        private string _VideosBinding = "";
        private string _RevisitasBinding = "";
        private string _CursosBiblicosBinding = "";        
        #endregion

        #region Propiedades Modal
        public string TiempoBinding
        {
            get { return _TiempoBinding; }
            set
            {
                _TiempoBinding = value;
                OnPropertyChanged();
            }
        }
        public string RevistasBinding
        {
            get { return _RevistasBinding; }
            set
            {
                _RevistasBinding = value;
                OnPropertyChanged();
            }
        }
        public string FolletosBinding
        {
            get { return _FolletosBinding; }
            set
            {
                _FolletosBinding = value;
                OnPropertyChanged();
            }
        }
        public string LibrosBinding
        {
            get { return _LibrosBinding; }
            set
            {
                _LibrosBinding = value;
                OnPropertyChanged();
            }
        }
        public string TratadosBinding
        {
            get { return _TratadosBinding; }
            set
            {
                _TratadosBinding = value;
                OnPropertyChanged();
            }
        }
        public string VideosBinding
        {
            get { return _VideosBinding; }
            set
            {
                _VideosBinding = value;
                OnPropertyChanged();
            }
        }
        public string RevisitasBinding
        {
            get { return _RevisitasBinding; }
            set
            {
                _RevisitasBinding = value;
                OnPropertyChanged();
            }
        }
        public string CursosBiblicosBinding
        {
            get { return _CursosBiblicosBinding; }
            set
            {
                _CursosBiblicosBinding = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Atributos Informe
        private bool _IsOcultar = true;
        private bool _IsMostrarModal = false;
        private bool _IsMostrar = false;
        private string _ImagenPay = "ic_play_circle.png";
        private string _ImagenPause = "ic_pause_circle.png";
        private string _ImagenStop = "ic_stop.png";
        private bool Pausado = false;
        private Color _FondoAtras = Color.White;
        private string _FondoOpacity = "1";
        private Frame _InformeModal = null;
        #endregion

        #region Propiedades Informe
        public Frame InformeModal
        {
            get { return _InformeModal; }
            set
            {
                _InformeModal = value;
                OnPropertyChanged();
            }
        }        
        public Color FondoAtras
        {
            get { return _FondoAtras; }
            set
            {
                _FondoAtras = value;
                ; OnPropertyChanged();
            }
        }        
        public string FondoOpacity
        {
            get { return _FondoOpacity; }
            set
            {
                _FondoOpacity = value;
                OnPropertyChanged();
            }
        }        
        public bool IsMostrarModal
        {
            get { return _IsMostrarModal; }
            set
            {
                _IsMostrarModal = value;
                OnPropertyChanged();
            }
        }        
        public string ImagenPlay
        {
            get { return _ImagenPay; }
            set
            {
                _ImagenPay = value;
                OnPropertyChanged();
            }
        }
        public string ImagenPause
        {
            get { return _ImagenPause; }
            set
            {
                _ImagenPause = value;
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
            get { return _IsOcultar; }
            set
            {
                _IsOcultar = value;
                OnPropertyChanged();
            }
        }
        public bool IsMostrar
        {
            get { return _IsMostrar; }
            set
            {
                _IsMostrar = value;
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
            DependencyService.Get<IMessage>().ShortToast("Añadido al Informe");
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
            Tiempo = oTiempo;
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
        private void Play()
        {
            IsOcultar = false;
            IsMostrar = true;
            if (!Pausado)
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
            Pausado = true;
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
                FondoAtras = Color.Gray;
                FondoOpacity = "0.7";
                TiempoBinding = (Horas + ":" + Minutos + ":" + Segundos);
                var oContentView = new InformeModalPage();
                InformeModal = oContentView.CargarModalInforme();
                OTiempo = "00:00:00";
                TiempoInicial = "";
            }
        }
        private void Cancelar()
        {
            IsMostrarModal = false;
            FondoAtras = new Color();
            FondoOpacity = "1";
            LimpiarCamposGuardar();
        }
        #endregion

        
        //DependencyService.Get<IMessage>().LongToast(ex.Message);
        #region Constructor
        public InformeViewModel()
        {
            var Informes = servicio.Consultar();
        }
        #endregion
    }
}
