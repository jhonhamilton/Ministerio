using Ministerio.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ministerio.View.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformePage : ContentPage
    {
        public InformePage()
        {
            InitializeComponent();
        }
        protected override void OnDisappearing()
        {
            MainViewModel.GetInstance().InformeView = new InformeViewModel();
            this.InitializeComponent();
        }
    }
}