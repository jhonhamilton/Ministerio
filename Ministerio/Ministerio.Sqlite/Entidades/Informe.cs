using SQLite;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ministerio.Sqlite.Entidades
{
    [Table("Informe")]
    public class Informe : INotifyPropertyChanged
    {

        private int _Id;
        private int _Hora;
        private int _Minutos;
        private int _Segundos;
        private int _Revisitas;
        private int _Revistas;
        private int _Folletos;
        private int _TratadosArticulos;
        private int _Libros;
        private int _Videos;
        private int _CursosBiblicos;
        private DateTime _Fecha;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        public int Hora
        {
            get { return _Hora; }
            set { _Hora = value; OnPropertyChanged(); }
        }
        public int Minutos
        {
            get { return _Minutos; }
            set { _Minutos = value; OnPropertyChanged(); }
        }
        public int Segundos
        {
            get { return _Segundos; }
            set { _Segundos = value; OnPropertyChanged(); }
        }
        public int Revisitas
        {
            get { return _Revisitas; }
            set { _Revisitas = value; OnPropertyChanged(); }
        }
        public int Revistas
        {
            get { return _Revistas; }
            set { _Revistas = value; OnPropertyChanged(); }
        }
        public int Folletos
        {
            get { return _Folletos; }
            set { _Folletos = value; OnPropertyChanged(); }
        }
        public int TratadosArticulos
        {
            get { return _TratadosArticulos; }
            set { _TratadosArticulos = value; OnPropertyChanged(); }
        }
        public int Libros
        {
            get { return _Libros; }
            set { _Libros = value; OnPropertyChanged(); }
        }
        public int Videos
        {
            get { return _Videos; }
            set { _Videos = value; OnPropertyChanged(); }
        }
        public int CursosBiblicos
        {
            get { return _CursosBiblicos; }
            set { _CursosBiblicos = value; OnPropertyChanged(); }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }
    }
}