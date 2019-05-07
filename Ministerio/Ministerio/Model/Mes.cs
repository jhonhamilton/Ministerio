using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ministerio.Model
{
    public class Mes :INotifyPropertyChanged
    {
        private int _row { get; set; }
        private int _Id { get; set; }
        private int _Indice { get; set; }
        private string _Nombre { get; set; }
        private int _Revisitas { get; set; }
        private int _Videos { get; set; }
        private int _Publicaciones { get; set; }
        private int _CursosBiblicos { get; set; }
        private string _Tiempo { get; set; }
        private bool _IsVisible { get; set; }

        public int Row { get { return _row; } set { _row = value; OnPropertyChanged(); } }
        public int Id { get { return _Id; } set { _Id = value; OnPropertyChanged(); } }
        public int Indice { get { return _Indice; } set { _Indice = value; OnPropertyChanged(); } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value; OnPropertyChanged(); } }
        public int Revisitas { get { return _Revisitas; } set { _Revisitas = value; OnPropertyChanged(); } }
        public int Videos { get { return _Videos; } set { _Videos = value; OnPropertyChanged(); } }
        public int Publicaciones { get { return _Publicaciones; } set { _Publicaciones = value; OnPropertyChanged(); } }
        public int CursosBiblicos { get { return _CursosBiblicos; } set { _CursosBiblicos = value; OnPropertyChanged(); } }
        public string Tiempo { get { return _Tiempo; } set { _Tiempo = value; OnPropertyChanged(); } }
        public bool IsVisible { get { return _IsVisible; } set { _IsVisible = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }
    }
}
