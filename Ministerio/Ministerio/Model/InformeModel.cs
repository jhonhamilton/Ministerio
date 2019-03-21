using Ministerio.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ministerio.Model
{
    public class InformeModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _id;
        private string _Tiempo = "00:00:00";
        private string _OTiempo = "00:00:00";
        private int _Revisitas;
        private int _Folletos;
        private int _Revistas;
        private int _Libros;
        private int _Tratados;
        private int _Videos;
        private int _CursosBiblicos;
        private bool _IsLoadd;
        private bool _IsEnable;
        private string _TiempoInicial;
        private int _Horas = 0;
        private int _Minutos = 0;
        private int _Segundos = 0;
        private int _Publicaciones;
        public int Publicaciones
        {
            get { return _Publicaciones; }
            set
            {
                _Publicaciones = value;
                OnPropertyChanged();
            }
        }
        public int Horas
        {
            get { return _Horas; }
            set
            {
                _Horas = value;
                OnPropertyChanged();
            }
        }
        public int Minutos
        {
            get { return _Minutos; }
            set
            {
                _Minutos = value;
                OnPropertyChanged();
            }
        }
        public int Segundos
        {
            get { return _Segundos; }
            set
            {
                _Segundos = value;
                OnPropertyChanged();
            }
        }
        public string TiempoInicial
        {
            get { return _TiempoInicial; }
            set
            {
                _TiempoInicial = value;
                OnPropertyChanged();
            }
        }
        public bool IsEnable
        {
            get { return _IsEnable; }
            set
            {
                _IsEnable = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoad
        {
            get { return _IsLoadd = false; }
            set
            {
                _IsLoadd = value;
                OnPropertyChanged();
            }

        }
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Tiempo
        {
            get { return _Tiempo; }
            set
            {
                _Tiempo = value;
                OnPropertyChanged();
            }
        }
        public string OTiempo
        {
            get { return _OTiempo; }
            set
            {
                _OTiempo = value;
                OnPropertyChanged();
            }
        }
        public int Revisitas
        {
            get { return _Revisitas; }
            set
            {
                _Revisitas = value;
                OnPropertyChanged();
            }
        }
        public int Revistas
        {
            get { return _Revistas; }
            set
            {
                _Revistas = value;
                OnPropertyChanged();
            }
        }
        public int Folletos
        {
            get { return _Folletos; }
            set
            {
                _Folletos = value;
                OnPropertyChanged();
            }
        }
        public int Libros
        {
            get { return _Libros; }
            set
            {
                _Libros = value;
                OnPropertyChanged();
            }
        }
        public int Tratados
        {
            get { return _Tratados; }
            set
            {
                _Tratados = value;
                OnPropertyChanged();
            }
        }
        public int Videos
        {
            get { return _Videos; }
            set
            {
                _Videos = value;
                OnPropertyChanged();
            }
        }
        public int CursosBiblicos
        {
            get { return _CursosBiblicos; }
            set
            {
                _CursosBiblicos = value;
                OnPropertyChanged();
            }
        }
        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }
        InformeServicio servicio = new InformeServicio();
        public InformeModel()
        {
            //Informes = new ObservableCollection<InformeModel>();
        }
        public ObservableCollection<InformeModel> _Informes { get; set; }
        //public ObservableCollection<InformeModel> Informes
        //{
        //    get { return _Informes; }
        //    set
        //    {
        //        _Informes = value;
        //        OnPropertyChanged();
        //    }
        //}
    }
}
