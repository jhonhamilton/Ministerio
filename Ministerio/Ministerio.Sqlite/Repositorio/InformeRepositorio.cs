using Ministerio.Sqlite.Entidades;
using SQLite;
//using SQLite.Net;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Ministerio.Sqlite.Repositorio
{
    public class InformeRepositorio : IDisposable
    {
        private SQLiteConnection connection;        
        public string EstadoMensaje;        
        public InformeRepositorio()
        {
            var dataBasePath = DependencyService.Get<IConfig>().DataBasePath("Ministerio.db3");
            connection = new SQLiteConnection(dataBasePath);
            connection.CreateTable<Informe>();
        }        
        public int AgregarInforme(Informe informe)
        {
            int resultado = 0;
            try
            {
                if (informe.Hora == 0 && informe.Minutos == 0 && informe.Segundos == 0 && informe.Videos == 0 && informe.TratadosArticulos == 0 && informe.Revistas == 0
                    && informe.Revisitas == 0 && informe.Libros == 0 && informe.Folletos == 0 && informe.CursosBiblicos == 0)
                {
                    EstadoMensaje = string.Format("No hay nada para guardar");
                }
                else
                {
                    resultado = connection.Insert(informe);
                    EstadoMensaje = string.Format("Informe guardado!!!");
                }
            }
            catch (Exception ex)
            {
                EstadoMensaje = ex.Message;
            }
            return resultado;
        }
        public int UpdateInforme(Informe informe)
        {
            int resultado = 0;
            try
            {
                resultado = connection.Update(informe);
                EstadoMensaje = string.Format("Informe Actualizado!!!");
            }
            catch (Exception ex)
            {
                EstadoMensaje = ex.Message;
            }
            return resultado;
        }
        public ObservableCollection<Informe> ObtenerTodosInformes()
        {
            try
            {
                return new ObservableCollection<Informe>(connection.Table<Informe>().OrderBy(c => c.Fecha).ToList());
            }
            catch (Exception ex)
            {
                EstadoMensaje = ex.Message;
            }
            return new ObservableCollection<Informe>(Enumerable.Empty<Informe>().ToList());
        }
        public void DeleteInforme(Informe informe)
        {
            try
            {
                connection.Delete(informe);
                EstadoMensaje = "Informe Eliminado";
            }
            catch (Exception ex)
            {
                EstadoMensaje = ex.Message;
            }
        }
        public Informe GetInforme(int idInforme)
        {
            return connection.Table<Informe>().FirstOrDefault(c => c.Id == idInforme);
        }
        public bool DeteleAll()
        {
            bool resultado = false;
            try
            {
                connection.DeleteAll<Informe>();
                resultado = true;
            }
            catch (Exception ex)
            {
                EstadoMensaje = ex.Message;
            }
            return resultado;
        }
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
