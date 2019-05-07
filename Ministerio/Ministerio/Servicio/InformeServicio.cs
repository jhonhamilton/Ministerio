using Ministerio.Interfaces;
using Ministerio.Sqlite.Entidades;
using Ministerio.Sqlite.Repositorio;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Ministerio.Servicio
{
    public class InformeServicio
    {
        private InformeRepositorio conext;
        public InformeServicio()
        {
            this.conext = new InformeRepositorio();
        }
        public ObservableCollection<Informe> Consultar()
        {
            return this.conext.ObtenerTodosInformes();
        }
        public void Guardar(Informe informe)
        {
            this.conext.AgregarInforme(informe);            
            DependencyService.Get<IMessage>().LongToast(this.conext.EstadoMensaje);
        }
        public void Modificar(Informe informe)
        {
            this.conext.UpdateInforme(informe);
            DependencyService.Get<IMessage>().LongToast(this.conext.EstadoMensaje);
        }
        public void Eliminar(Informe informe)
        {
            this.conext.DeleteInforme(informe);
            DependencyService.Get<IMessage>().LongToast(this.conext.EstadoMensaje);
        }
        public void DeleteAll()
        {
            if (!this.conext.DeteleAll())
            {
                DependencyService.Get<IMessage>().LongToast(this.conext.EstadoMensaje);
            }
            else
            {
                DependencyService.Get<IMessage>().LongToast("Eliminación Exitosa");
            }
        }
    }
}
