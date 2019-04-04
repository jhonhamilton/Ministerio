using BottomBar.XamarinForms;
using Ministerio.View.Paginas;
using Xamarin.Forms;
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
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();            
            if (CurrentPage is InformeAllPage page)
            {
                Title = "Informes";
            }
            else
            {
                Title = "Inicio";
            }
        }
    }
}