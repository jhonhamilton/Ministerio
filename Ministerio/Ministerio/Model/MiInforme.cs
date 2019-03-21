using System;
using System.Collections.Generic;
using System.Text;

namespace Ministerio.Model
{
    public class MiInforme
    {
        public string Id { get; set; }
        public string Tiempo { get; set; }
        public int Revisitas { get; set; }
        public int Revistas { get; set; }
        public int Folletos { get; set; }
        public int Tratados { get; set; }
        public int Videos { get; set; }
        public int Libros { get; set; }
        public int CursosBiblicos { get; set; }
    }
}
