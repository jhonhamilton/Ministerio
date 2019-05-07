using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ministerio.Model
{
    public class MiInforme : INotifyPropertyChanged
    {
        private string _Tiempo { get; set; }
        private int _Revisitas { get; set; }
        private int _Videos { get; set; }
        private int _Publicaciones { get; set; }
        private int _CursosBiblicos { get; set; }

        public string Tiempo
        {
            get { return _Tiempo; }
            set
            {
                _Tiempo = value;
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
        public int Videos
        {
            get { return _Videos; }
            set
            {
                _Videos = value;
                OnPropertyChanged();
            }
        }
        public int Publicaciones
        {
            get { return _Publicaciones; }
            set
            {
                _Publicaciones = value;
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

        public MiInforme(string tiempo, int revisitas, int videos, int publicaciones, int cursos)
        {
            this.Tiempo = tiempo;
            this.Revisitas = revisitas;
            this.Videos = videos;
            this.Publicaciones = publicaciones;
            this.CursosBiblicos = cursos;
        }
        public MiInforme()
        {
            this.Tiempo = "00:00:00";
            this.Revisitas = 0;
            this.Videos = 0;
            this.Publicaciones = 0;
            this.CursosBiblicos = 0;
        }
        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
