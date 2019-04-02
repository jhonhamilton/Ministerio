using BottomBar.XamarinForms;
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

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetBarSelectedItemColor(Xamarin.Forms.Color.White);
            On<Android>().SetBarItemColor(Xamarin.Forms.Color.Gray);
        }
    }
}