using Ministerio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ministerio.Servicio
{
    public class InformeServicio
    {
        public ObservableCollection<InformeModel> informes { get; set; }
        public InformeServicio()
        {
            if (informes == null)
            {
                informes = new ObservableCollection<InformeModel>();
            }
        }

        public ObservableCollection<InformeModel> Consultar()
        {
            return informes;
        }

        public void Guardar(InformeModel informe)
        {
            informes.Add(informe);
        }
        public void Modificar(InformeModel informe)
        {
            for (int i = 0; i < informes.Count; i++)
            {
                if (informes[i].Id == informe.Id)
                {
                    informes[i] = informe;
                }
            }
        }
        public void Eliminar(string idInforme)
        {
            var oInformEliminar = new InformeModel();
            for (int i = 0; i < informes.Count; i++)
            {
                if (informes[i].Id == idInforme)
                {
                    oInformEliminar = informes[i];
                    break;
                }
            }
            informes.Remove(oInformEliminar);
        }
    }
}
