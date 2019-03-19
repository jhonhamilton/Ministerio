using Ministerio.ViewModel;

namespace Ministerio.Infraestructura
{
    public class InstanciaLocalizada
    {
        public MainViewModel Main { get; set; }
        public InstanciaLocalizada()
        {
            Main = new MainViewModel();
        }
    }
}
