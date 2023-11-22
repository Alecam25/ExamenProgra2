using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamenPrograWeb.Clases
{
    public class Equipo
    {
        public int IDEquipo { get; set; }
        public int UsuariosID { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }



        public Equipo(int IDequipo, int usuariosID, string Tipoequipo, string modelo)
        {
            this.IDEquipo = IDequipo;
            this.UsuariosID = usuariosID;
            this.TipoEquipo = Tipoequipo;
            this.Modelo = modelo;
        }


        public Equipo() { }

        public static int Agregar(string UsuariosID, string TipoEquipo, string Modelo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBCONEXION.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAR_EQUIPOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuariosID", UsuariosID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", TipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Modelo));

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
        public static int Borrar(string IDEquipos )
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBCONEXION.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_EQUIPOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IDEquipos", IDEquipos));
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

        public static int Modificar(string UsuariosID, string TipoEquipo, string Modelo, string IDEquipos)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBCONEXION.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICAR_EQUIPOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuariosID", UsuariosID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", TipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Modelo));
                    cmd.Parameters.Add(new SqlParameter("@IDEquipos", IDEquipos));
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