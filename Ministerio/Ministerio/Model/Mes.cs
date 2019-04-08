using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministerio.Model
{
    public class Mes
    {
        public int Id { get; set; }
        public int Indice { get; set; }
        public string Nombre { get; set; }
        public int Revisitas { get; set; }
        public int Videos { get; set; }
        public int Publicaciones { get; set; }
        public int CursosBiblicos { get; set; }
        public string Tiempo { get; set; }
    }
}
