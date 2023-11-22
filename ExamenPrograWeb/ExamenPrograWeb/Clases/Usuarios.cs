using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamenPrograWeb.Clases
{
    public class Usuarios
    {

     public int IDUsuarios { get; set; }
     public string Nombre { get; set; }
     public string Correo { get; set; }
     public string Telefono { get; set; }
       
        public Usuarios(int IDusuarios, string nombre, string correo, string telefono)
        {
            this.IDUsuarios = IDusuarios;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Telefono = telefono;
        }

        public Usuarios() { }

        public static int Agregar(string Nombre, string Correo, string Telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBCONEXION.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAR_USUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Correo", Correo));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
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

        public static int Borrar( string IDUsuarios)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBCONEXION.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_Usuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IDusuarios", IDUsuarios));
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
        public static int Modificar(string Nombre, string Correo, string Telefono, string IDUsuarios)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBCONEXION.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICAR_USUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Correo", Correo));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
                    cmd.Parameters.Add(new SqlParameter("@IDusuarios", IDUsuarios));
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