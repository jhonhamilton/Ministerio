using System;

namespace Ministerio.Sqlite.Modelo
{
    public class Informe
    {
        public int Id { get; set; }
        public int Hora { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public int Revisitas { get; set; }
        public int Revistas { get; set; }
        public int Folletos { get; set; }
        public int TratadosArticulos { get; set; }
        public int Libros { get; set; }
        public int Videos { get; set; }
        public int CursosBiblicos { get; set; }
        public DateTime Fecha { get; set; }
    }
}
