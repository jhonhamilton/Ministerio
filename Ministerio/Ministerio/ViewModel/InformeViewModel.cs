using Ministerio.Modals;
using Ministerio.Model;
using Ministerio.Servicio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ministerio.ViewModel
{
    public class InformeViewModel : InformeModel
    {
        InformeServicio servicio = new InformeServicio();
        Stopwatch mStopWatch = new Stopwatch();
        InformeModel informeModel;
        private Frame _InformeModal = null;
        public Frame InformeModal
        {
            get { return _InformeModal; }
            set
            {
                _InformeModal = value;
                OnPropertyChanged();
            }
        }
        private Color _FondoAtras = Color.White;
        public Color FondoAtras
        {
            get { return _FondoAtras; }
            set
            {
                _FondoAtras = value;
;                OnPropertyChanged();
            }
        }
        private string _FondoOpacity = "1";
        public string FondoOpacity
        {
            get { return _FondoOpacity; }
            set
            {
                _FondoOpacity = value;
                OnPropertyChanged();
            }
        }
        private bool _IsOcultar = true;
        private bool _IsMostrarModal = false;
        private bool _IsMostrar = false;
        private string _ImagenPay;
        private string _ImagenPause;
        private string _ImagenStop;
        private bool Pausado = false;
        List<MiInforme> _MiInforme;
        public bool IsMostrarModal
        {
            get { return _IsMostrarModal; }
            set
            {
                _IsMostrarModal = value;
                OnPropertyChanged();
            }
        }
        public List<MiInforme> MiInforme
        {
            get { return _MiInforme; }
            set
            {
                _MiInforme = value;
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
        public InformeViewModel()
        {
            Informes = servicio.Consultar();
            Publicaciones = (Libros + Folletos + Revistas + Tratados);
            ImagenPlay = "ic_play_circle.png";
            ImagenPause = "ic_pause_circle.png";
            ImagenStop = "ic_stop.png";
            if (OTiempo != null)
            {
                Horas += Convert.ToInt32(OTiempo.Split(':')[0].ToString());
                Minutos += Convert.ToInt32(OTiempo.Split(':')[1].ToString());
                Segundos += Convert.ToInt32(OTiempo.Split(':')[2].ToString());
            }
        }
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
            Guid idInforme = Guid.NewGuid();
            informeModel = new InformeModel()
            {
                Tiempo = Tiempo,
                Libros = Libros,
                Revisitas = Revisitas,
                CursosBiblicos = CursosBiblicos,
                Videos = Videos,
                Tratados = Tratados,
                Folletos = Folletos,
                Id = idInforme.ToString()
            };
            servicio.Guardar(informeModel);
            await Task.Delay(500);
            IsLoad = false;
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
        private void Play()
        {
            IsOcultar = false;
            IsMostrar = true;
            if (!Pausado)
            {
                TiempoInicial = DateTime.Now.ToString("HH:mm:ss");
            }
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (!IsOcultar)
                {
                    mStopWatch.Start();
                    OTiempo = string.Format("{0:hh\\:mm\\:ss}", mStopWatch.Elapsed);
                }
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
            if (OTiempo != null)
            {
                Minutos += Convert.ToInt32(OTiempo.Split(':')[0].ToString());
                Minutos += Convert.ToInt32(OTiempo.Split(':')[1].ToString());
                Segundos += Convert.ToInt32(OTiempo.Split(':')[2].ToString());
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
                Tiempo = (Horas + ":" + Minutos + ":" + Segundos);
                IsMostrarModal = true;
                FondoAtras = Color.Gray;
                FondoOpacity = "0.7";
                var oContentView = new InformeModalPage
                {
                    Tiempo = Tiempo
                };
                InformeModal = oContentView.CargarModalInforme();
                OTiempo = "00:00:00";
            }            
        }
    }
}
