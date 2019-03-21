using Ministerio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ministerio.Servicio
{
    public class InformeServicio
    {
        public List<MiInforme> Informes { get; set; }
        public InformeServicio()
        {
            if (Informes == null)
            {
                Informes = new List<MiInforme>();
            }
        }

        public List<MiInforme> Consultar()
        {
            return Informes;
        }

        public void Guardar(MiInforme informe)
        {
            Informes.Add(informe);
        }
        public void Modificar(MiInforme informe)
        {
            for (int i = 0; i < Informes.Count; i++)
            {
                if (Informes[i].Id == informe.Id)
                {
                    Informes[i] = informe;
                }
            }
        }
        public void Eliminar(string idInforme)
        {
            var oInformEliminar = new MiInforme();
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
    }
}
