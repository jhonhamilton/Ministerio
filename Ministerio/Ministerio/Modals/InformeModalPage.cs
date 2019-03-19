using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Ministerio.Modals
{
    public class InformeModalPage : Frame
    {
        public string Tiempo { get; set; }
        public InformeModalPage()
        {
            this.Tiempo = "00:00:00";
        }

        public Frame CargarModalInforme()
        {
            var myGrid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition(){ Height = new GridLength(5, GridUnitType.Auto) },
                    new RowDefinition(){ Height = new GridLength(5, GridUnitType.Auto) },
                    new RowDefinition(){ Height = new GridLength(5, GridUnitType.Auto) },
                    new RowDefinition(){ Height = new GridLength(5, GridUnitType.Auto) },
                    new RowDefinition(){ Height = new GridLength(5, GridUnitType.Auto) },
                    new RowDefinition(){ Height = new GridLength(5, GridUnitType.Auto) },
                    new RowDefinition(){ Height = new GridLength(5, GridUnitType.Auto) },
                    new RowDefinition(){ Height = new GridLength(5, GridUnitType.Auto) },
                    new RowDefinition(){ Height = new GridLength(5, GridUnitType.Auto) }
                },
                ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition()
                    {
                        Width = new GridLength(10, GridUnitType.Auto)
                    },
                    new ColumnDefinition()
                    {
                        Width = new GridLength(15, GridUnitType.Auto)
                    },
                    new ColumnDefinition()
                    {
                        Width = new GridLength(10, GridUnitType.Auto)
                    },
                    new ColumnDefinition()
                    {
                        Width = new GridLength(10, GridUnitType.Auto)
                    },
                }
            };
            var oLabelHead = new Label() { Text = "Control de Registros" };
            for (int i = 0; i < myGrid.RowDefinitions.Count; i++)
            {
                var image1 = new Image() { Source = "Menos_ic_Res.png", WidthRequest = 40 };
                var oEntry = EscribirPlaceHolder(i, this.Tiempo);
                var image2 = new Image { Source = "Reloj_ic.png", WidthRequest = 40 };
                var image3 = new Image() { Source = "Mas_ic_Sum.png", WidthRequest = 40 };
                if(i == 0)
                {
                    myGrid.Children.Add(image1, 0, i);
                    myGrid.Children.Add(oEntry, 1, i);
                    myGrid.Children.Add(image2, 2, i);
                    myGrid.Children.Add(image3, 3, i);
                }
                else
                {
                    image1.HorizontalOptions = LayoutOptions.FillAndExpand;
                    oEntry.HorizontalOptions = LayoutOptions.FillAndExpand;
                    myGrid.Children.Add(image1, 0, i);
                    myGrid.Children.Add(oEntry, 1, i);                    
                    myGrid.Children.Add(image3, 3, i);
                }
                if (i == 8)
                {
                    var oCancelar = new Button() { Text = "Cancelar", HorizontalOptions = LayoutOptions.FillAndExpand };
                    var oAnadir = new Button() { Text = "Añadir", HorizontalOptions = LayoutOptions.FillAndExpand };
                    var oStack = new StackLayout() { Orientation = StackOrientation.Horizontal };
                    oStack.Children.Add(oCancelar);
                    oStack.Children.Add(oAnadir);
                    myGrid.Children.AddVertical(oStack);
                }                
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

        private Entry EscribirPlaceHolder(int posicion, string oTiempo)
        {
            var oEntry = new Entry();
            switch (posicion)
            {
                case 0:
                    oEntry.Placeholder = "Horas(hh:mm:ss)";
                    oEntry.Text = oTiempo;
                    break;
                case 1:
                    oEntry.Placeholder = "Revistas";
                    break;
                case 2:
                    oEntry.Placeholder = "Folletos";
                    break;
                case 3:
                    oEntry.Placeholder = "Libros";
                    break;
                case 4:
                    oEntry.Placeholder = "Tratados / Artículos";
                    break;
                case 5:
                    oEntry.Placeholder = "Vídeos";
                    break;
                case 6:
                    oEntry.Placeholder = "Revisitas";
                    break;
                default:
                    oEntry.Placeholder = "Cursos Bíblicos";
                    break;
            }
            return oEntry;
        }
    }
}