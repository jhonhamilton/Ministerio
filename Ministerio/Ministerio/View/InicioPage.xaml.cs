using BottomBar.XamarinForms;
using Ministerio.View.Paginas;
using Ministerio.ViewModel;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Ministerio.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : BottomBarPage
    {
        public InicioPage()
        {
            InitializeComponent();

            //On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            //On<Android>().SetBarSelectedItemColor(Xamarin.Forms.Color.White);
            //On<Android>().SetBarItemColor(Xamarin.Forms.Color.Gray);
        }

        //protected override void OnCurrentPageChanged()
        //{
        //    base.OnCurrentPageChanged();

        //    if (CurrentPage is InformeAllPage page)
        //    {
        //        MainViewModel.GetInstance().InformeAlls = new InformeAllViewModel();
        //    }
        //}
    }
}