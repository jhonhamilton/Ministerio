﻿using Ministerio.Sqlite.Entidades;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using SQLitePCL;

namespace Ministerio.Sqlite.Repositorio
{
    public class InformeRepositorio
    {
        private SQLiteConnection con;
        private static InformeRepositorio instancia;
        public string EstadoMensaje;
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
                    resultado = con.Insert(informe);
                    EstadoMensaje = string.Format("Informe guardado!!!");
                }
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

        public bool DeteleAll()
        {
            bool resultado = false;
            try
            {
                con.DeleteAll<Informe>();
                resultado = true;
            }
            catch (Exception ex)
            {
                EstadoMensaje = ex.Message;
            }
            return resultado;
        }
    }
}
