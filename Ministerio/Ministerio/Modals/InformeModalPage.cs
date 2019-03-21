using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace Ministerio.Modals
{
    public class InformeModalPage : Frame
    {
        public InformeModalPage()
        {
            //this.TiempoBinding = "00:00:00";
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
                    oCancelar.SetBinding(Button.CommandProperty, new Binding("CancelarCommand"));
                    var oAnadir = new Button() { Text = "Añadir", HorizontalOptions = LayoutOptions.FillAndExpand };
                    oAnadir.SetBinding(Button.CommandProperty, new Binding("GuardarCommand"));
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
                    oEntry.SetBinding(Entry.TextProperty, new Binding("TiempoBinding"));
                    oEntry.Placeholder = "Horas(hh:mm:ss)";
                    break;
                case 1:
                    oEntry.SetBinding(Entry.TextProperty, new Binding("RevistasBinding"));
                    oEntry.Placeholder = "Revistas";
                    break;
                case 2:
                    oEntry.SetBinding(Entry.TextProperty, new Binding("FolletosBinding"));
                    oEntry.Placeholder = "Folletos";
                    break;
                case 3:
                    oEntry.SetBinding(Entry.TextProperty, new Binding("LibrosBinding"));
                    oEntry.Placeholder = "Libros";
                    break;
                case 4:
                    oEntry.SetBinding(Entry.TextProperty, new Binding("TratadosBinding"));
                    oEntry.Placeholder = "Tratados / Artículos";
                    break;
                case 5:
                    oEntry.SetBinding(Entry.TextProperty, new Binding("VideosBinding"));
                    oEntry.Placeholder = "Vídeos";
                    break;
                case 6:
                    oEntry.SetBinding(Entry.TextProperty, new Binding("RevisitasBinding"));
                    oEntry.Placeholder = "Revisitas";
                    break;
                default:
                    oEntry.SetBinding(Entry.TextProperty, new Binding("CursosBiblicosBinding"));
                    oEntry.Placeholder = "Cursos Bíblicos";
                    break;
            }
            return oEntry;
        }
    }
}