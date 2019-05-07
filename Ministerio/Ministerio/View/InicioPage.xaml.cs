using BottomBar.XamarinForms;
using Ministerio.View.Paginas;
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
            if (CurrentPage is InformeAllPage)
            {
                Title = "Informes";
            }
            else if(CurrentPage is InformePage)
            {
                Title = "Inicio";
            }
            else
            {
                Title = "Inicio";
            }            
        }
        protected override bool OnBackButtonPressed()
        {
            if (CurrentPage is InformePage)
            {
                return base.OnBackButtonPressed();
            }
            else
            {
                return Regresar();
            }
        }
        private bool Regresar()
        {
            var masterPage = this;
            masterPage.CurrentPage = masterPage.Children[0];
            masterPage.CurrentPage.Focus();
            return true;
        }        
    }
}