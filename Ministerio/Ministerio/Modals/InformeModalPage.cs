using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace Ministerio.Modals
{
    public class InformeModalPage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string NombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }
        private string _TiempoBinding;
        private string _CancelarCommandBinding;
        private string _AceptarCommandBinding;
        private int _RevistasBinding;
        private int _FolletosBinding;
        private int _LibrosBinding;
        private int _TratadosBinding;
        private int _VideosBinding;
        private int _RevisitasBinding;
        private int _CursosBiblicosBinding;

        public string TiempoBinding
        {
            get { return _TiempoBinding; }
            set
            {
                _TiempoBinding = value;
                OnPropertyChanged();
            }
        }
        public string CancelarCommandBinding { get { return _CancelarCommandBinding; } set { _CancelarCommandBinding = value; OnPropertyChanged(); } }
        public string AceptarCommandBinding { get { return _AceptarCommandBinding; } set { _AceptarCommandBinding = value; OnPropertyChanged(); } }
        public int RevistasBinding { get { return _RevistasBinding; } set { _RevistasBinding = value; OnPropertyChanged(); } }
        public int FolletosBinding { get { return _FolletosBinding; } set { _FolletosBinding = value; OnPropertyChanged(); } }
        public int LibrosBinding { get { return _LibrosBinding; } set { _LibrosBinding = value; OnPropertyChanged(); } }
        public int TratadosBinding { get { return _TratadosBinding; } set { _TratadosBinding = value; OnPropertyChanged(); } }
        public int VideosBinding { get { return _VideosBinding; } set { _VideosBinding = value; OnPropertyChanged(); } }
        public int RevisitasBinding { get { return _RevisitasBinding; } set { _RevisitasBinding = value; OnPropertyChanged(); } }
        public int CursosBiblicosBinding { get { return _CursosBiblicosBinding; } set { _CursosBiblicosBinding = value; OnPropertyChanged(); } }
        public InformeModalPage()
        {
            this.TiempoBinding = "00:00:00";
            //this.RevistasBinding = 0;
            //this.FolletosBinding = 0;
            //this.LibrosBinding = 0;
            //this.TratadosBinding = 0;
            //this.VideosBinding = 0;
            //this.RevisitasBinding = 0;
            //this.CursosBiblicosBinding = 0;
        }

        public Frame CargarModalInforme()
        {
            var myGrid = new Grid();
            var oLabelHead = new Label() { Text = "Control de Registros" };
            for (int i = 0; i < 9; i++)
            {
                var image1 = new Image() { Source = "Menos_ic_Res.png", WidthRequest = 40 };                
                var oEntry = EscribirPlaceHolder(i);
                oEntry.Keyboard = Keyboard.Numeric;
                oEntry.HorizontalOptions = LayoutOptions.FillAndExpand;
                var image2 = new Image { Source = "Reloj_ic.png", WidthRequest = 40 };
                var image3 = new Image() { Source = "Mas_ic_Sum.png", WidthRequest = 40 };
                var lisView = new List<Xamarin.Forms.View>();
                var oStack = new StackLayout() { Orientation = StackOrientation.Horizontal };
                if (i == 0)
                {
                    oStack.Children.Add(image1);
                    oStack.Children.Add(oEntry);
                    oStack.Children.Add(image2);
                    oStack.Children.Add(image3);
                }
                else if (i == 8)
                {
                    var oCancelar = new Button() { Text = "Cancelar", HorizontalOptions = LayoutOptions.FillAndExpand };
                    oCancelar.SetBinding(Button.CommandProperty, new Binding() { Path = CancelarCommandBinding });
                    var oAnadir = new Button() { Text = "Añadir", HorizontalOptions = LayoutOptions.FillAndExpand };
                    oAnadir.SetBinding(Button.CommandProperty, new Binding() { Path = AceptarCommandBinding });
                    oStack.Children.Add(oCancelar);
                    oStack.Children.Add(oAnadir);                    
                }
                else
                {
                    oStack.Children.Add(image1);
                    oStack.Children.Add(oEntry);                    
                    oStack.Children.Add(image3);
                }
                myGrid.Children.AddVertical(oStack);
            }
            var stack = new StackLayout()
            {
                Children =
                {
                    myGrid
                }
            };
            var oContent = new Frame()
            {
                Content = stack
            };
            return oContent;
        }

        private Entry EscribirPlaceHolder(int posicion)
        {
            var oEntry = new Entry();
            switch (posicion)
            {
                case 0:
                    oEntry.SetBinding(Entry.TextProperty, new Binding() { Path = nameof(TiempoBinding) });
                    oEntry.Placeholder = "Horas(hh:mm:ss)";
                    break;
                case 1:                    
                    oEntry.SetBinding(Entry.TextProperty, new Binding(nameof(RevistasBinding)));                    
                    oEntry.Placeholder = "Revistas";
                    break;
                case 2:
                    oEntry.SetBinding(Entry.TextProperty, new Binding() { Path = nameof(FolletosBinding) });
                    oEntry.Placeholder = "Folletos";
                    break;
                case 3:
                    oEntry.SetBinding(Entry.TextProperty, new Binding() { Path = nameof(LibrosBinding) });
                    oEntry.Placeholder = "Libros";
                    break;
                case 4:
                    oEntry.SetBinding(Entry.TextProperty, new Binding() { Path = nameof(TratadosBinding) });
                    oEntry.Placeholder = "Tratados / Artículos";
                    break;
                case 5:
                    oEntry.SetBinding(Entry.TextProperty, new Binding() { Path = nameof(VideosBinding) });
                    oEntry.Placeholder = "Vídeos";
                    break;
                case 6:
                    oEntry.SetBinding(Entry.TextProperty, new Binding() { Path = nameof(RevisitasBinding) });
                    oEntry.Placeholder = "Revisitas";
                    break;
                default:
                    oEntry.SetBinding(Entry.TextProperty, new Binding() { Path = nameof(CursosBiblicosBinding) });
                    oEntry.Placeholder = "Cursos Bíblicos";
                    break;
            }
            return oEntry;
        }
    }
}