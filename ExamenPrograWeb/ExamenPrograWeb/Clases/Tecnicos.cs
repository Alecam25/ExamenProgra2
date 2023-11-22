using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamenPrograWeb.Clases
{
    public class Tecnicos
    {
        public int IDTecnicos{ get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        public Tecnicos(int IDtecnicos, string nombre, string especialidad)
        {
            this.IDTecnicos = IDtecnicos;
            this.Nombre = nombre;
            this.Especialidad = especialidad;
        }


        public Tecnicos() { }

        public static int Agregar(string Nombre, string Especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBCONEXION.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAR_TECNICOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", Especialidad));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
        public static int Borrar(string IDtecnicos)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBCONEXION.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_TECNICOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IDtecnicos", IDtecnicos));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static int Modificar(string Nombre, string Especialidad, string IDtecnicos)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBCONEXION.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICAR_TECNICOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", Especialidad));
                    cmd.Parameters.Add(new SqlParameter("@IDtecnicos", IDtecnicos));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static void Consultar() { }










    }
}

