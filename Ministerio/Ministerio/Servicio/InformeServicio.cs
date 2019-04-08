using Ministerio.Interfaces;
using Ministerio.Model;
using Ministerio.Sqlite.Entidades;
using Ministerio.Sqlite.Repositorio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Ministerio.Servicio
{
    public class InformeServicio
    {
        public List<Informe> Informes { get; set; }
        public InformeServicio()
        {
            if (Informes == null)
            {
                Informes = new List<Informe>();
            }
        }

        public IEnumerable<Informe> Consultar()
        {
            return InformeRepositorio.Instancia.ObtenerTodosInformes();
        }

        public void Guardar(Informe informe)
        {
            InformeRepositorio.Instancia.AgregarInforme(informe);
            DependencyService.Get<IMessage>().LongToast(InformeRepositorio.Instancia.EstadoMensaje);
            //DependencyService.Get<IMessage>().LongToast(InformeRepositorio.Instancia.estadoMensaje);
        }
        public void Modificar(Informe informe)
        {
            for (int i = 0; i < Informes.Count; i++)
            {
                if (Informes[i].Id == informe.Id)
                {
                    Informes[i] = informe;
                }
            }
        }
        public void Eliminar(int idInforme)
        {
            var oInformEliminar = new Informe();
            for (int i = 0; i < Informes.Count; i++)
            {
                if (Informes[i].Id == idInforme)
                {
                    oInformEliminar = Informes[i];
                    break;
                }
            }
            Informes.Remove(oInformEliminar);
        }

        public void DeleteAll()
        {
            if (!InformeRepositorio.Instancia.DeteleAll())
            {
                DependencyService.Get<IMessage>().LongToast(InformeRepositorio.Instancia.EstadoMensaje);
            }
            else
            {
                DependencyService.Get<IMessage>().LongToast("Eliminación Exitosa");
            }
        }
    }
}
