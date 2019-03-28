using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ministerio.Sqlite.Entidades;
using SQLite;

namespace Ministerio.Sqlite.Repositorio
{
    public class InformeRepositorio
    {
        private SQLiteConnection con;
        private static InformeRepositorio instancia;
        public static InformeRepositorio Instancia
        {
            get
            {
                if (instancia == null)
                {
                    throw new Exception("Debe llamar al inicializador");
                }
                return instancia;
            }
        }
        public static void Inicializador(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new InformeRepositorio(filename);
        }
        private InformeRepositorio(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Informe>();
        }

        public string EstadoMensaje;
        public int AgregarInforme(Informe informe)
        {
            int resultado = 0;
            try
            {
                resultado = con.Insert(informe);
                EstadoMensaje = string.Format("Informe agregado!!!");
            }
            catch (Exception ex)
            {
                EstadoMensaje = ex.Message;
            }
            return resultado;
        }

        public IEnumerable<Informe> ObtenerTodosInformes()
        {
            try
            {
                return con.Table<Informe>();
            }
            catch (Exception ex)
            {
                EstadoMensaje = ex.Message;
            }
            return Enumerable.Empty<Informe>();
        }
    }
}
