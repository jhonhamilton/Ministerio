using Ministerio.Model;

using Xamarin.Forms;

namespace Ministerio.Modals
{
    public class InformeModalPage : Frame
    {
        public InformeModalPage()
        {
            //this.TiempoBinding = "00:00:00";
        }

        public TableView CargarModalInforme(MiInforme miInforme)
        {
            var oTable = new TableView() { Intent = TableIntent.Menu };
            var oTableRoot = new TableRoot();
            var oTableSection = new TableSection() { Title = "Mi Informe" };

            var oLabel0 = new Label() { Text = "Tiempo", VerticalOptions = LayoutOptions.Center, TextColor = Color.Black };
            var oLabel01 = new Label() { Text = miInforme.Tiempo, HorizontalOptions = LayoutOptions.EndAndExpand, TextColor = Color.Black };
            var oStack0 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            oStack0.Children.Add(oLabel0);
            oStack0.Children.Add(oLabel01);
            var oViewCell0 = new ViewCell()
            {
                View = oStack0
            };
            oTableSection.Add(oViewCell0);

            var oLabel10 = new Label() { Text = "Publicaciones", VerticalOptions = LayoutOptions.Center, TextColor = Color.Black };
            var oLabel11 = new Label() { Text = miInforme.Publicaciones.ToString(), HorizontalOptions = LayoutOptions.EndAndExpand, TextColor = Color.Black };
            var oStack1 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            oStack1.Children.Add(oLabel10);
            oStack1.Children.Add(oLabel11);
            var oViewCell1 = new ViewCell()
            {
                View = oStack1
            };
            oTableSection.Add(oViewCell1);


            var oLabel20 = new Label() { Text = "Revisitas", VerticalOptions = LayoutOptions.Center, TextColor = Color.Black };
            var oLabel21 = new Label() { Text = miInforme.Revisitas.ToString(), HorizontalOptions = LayoutOptions.EndAndExpand, TextColor = Color.Black };
            var oStack2 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            oStack2.Children.Add(oLabel20);
            oStack2.Children.Add(oLabel21);
            var oViewCell2 = new ViewCell()
            {
                View = oStack2
            };
            oTableSection.Add(oViewCell2);


            var oLabel30 = new Label() { Text = "Cursos Biblicos", VerticalOptions = LayoutOptions.Center, TextColor = Color.Black };
            var oLabel31 = new Label() { Text = miInforme.CursosBiblicos.ToString(), HorizontalOptions = LayoutOptions.EndAndExpand, TextColor = Color.Black };
            var oStack3 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            oStack3.Children.Add(oLabel30);
            oStack3.Children.Add(oLabel31);
            var oViewCell3 = new ViewCell()
            {
                View = oStack3
            };
            oTableSection.Add(oViewCell3);


            var oLabel40 = new Label() { Text = "Videos", VerticalOptions = LayoutOptions.Center, TextColor = Color.Black };
            var oLabel41 = new Label() { Text = miInforme.Videos.ToString(), HorizontalOptions = LayoutOptions.EndAndExpand, TextColor = Color.Black };
            var oStack4 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            oStack4.Children.Add(oLabel40);
            oStack4.Children.Add(oLabel41);
            var oViewCell4 = new ViewCell()
            {
                View = oStack4
            };
            oTableSection.Add(oViewCell4);
                        
            oTable.Root = oTableRoot;
            oTableRoot.Add(oTableSection);
            //var oContent = new Frame()
            //{
            //    Content = oTable
            //};
            //return oContent;
            return oTable;




            //var oLabelHead = new Label() { Text = "Control de Registros" };
            //for (int i = 0; i < 9; i++)
            //{
            //    var image1 = new Image() { Source = "Menos_ic_Res.png", WidthRequest = 40 };
            //    var oEntry = EscribirPlaceHolder(i);
            //    oEntry.Keyboard = Keyboard.Numeric;
            //    oEntry.HorizontalOptions = LayoutOptions.FillAndExpand;
            //    var image2 = new Image { Source = "Reloj_ic.png", WidthRequest = 40 };
            //    var image3 = new Image() { Source = "Mas_ic_Sum.png", WidthRequest = 40 };
            //    var lisView = new List<Xamarin.Forms.View>();
            //    var oStack = new StackLayout() { Orientation = StackOrientation.Horizontal };
            //    if (i == 0)
            //    {
            //        oStack.Children.Add(image1);
            //        oStack.Children.Add(oEntry);
            //        oStack.Children.Add(image2);
            //        oStack.Children.Add(image3);
            //    }
            //    else if (i == 8)
            //    {
            //        var oCancelar = new Button() { Text = "Cancelar", HorizontalOptions = LayoutOptions.FillAndExpand };
            //        oCancelar.SetBinding(Button.CommandProperty, new Binding("CancelarCommand"));
            //        var oAnadir = new Button() { Text = "Añadir", HorizontalOptions = LayoutOptions.FillAndExpand };
            //        oAnadir.SetBinding(Button.CommandProperty, new Binding("GuardarCommand"));
            //        oStack.Children.Add(oCancelar);
            //        oStack.Children.Add(oAnadir);
            //    }
            //    else
            //    {
            //        oStack.Children.Add(image1);
            //        oStack.Children.Add(oEntry);
            //        oStack.Children.Add(image3);
            //    }
            //    myGrid.Children.AddVertical(oStack);
            //}
            //var stack = new StackLayout()
            //{
            //    Children =
            //    {
            //        myGrid
            //    }
            //};
            //var oContent = new Frame()
            //{
            //    Content = stack
            //};
            //return oContent;
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