using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenPrograWeb
{
    public partial class Usuarios : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM USUARIOS"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int retorno =  Clases.Usuarios.Agregar(tNombre.Text, tCorreo.Text, tTelefono.Text);
            if (retorno > 0)
            {
                alertas("Usuario Agregado");
                LlenarGrid();
            }
            else
            {
                alertas("Error al Agregar el Usuario");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int retorno = Clases.Usuarios.Borrar(tIDusarios.Text);
            if (retorno > 0)
            {
                alertas("Usuario Borrado");
                LlenarGrid();
            }
            else
            {
                alertas("Error al Borrar el Usuario");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int retorno = Clases.Usuarios.Modificar(tNombre.Text, tCorreo.Text, tTelefono.Text, tIDusarios.Text);
            if (retorno > 0)
            {
                alertas("Usuario Modificado");
                LlenarGrid();
            }
            else
            {
                alertas("Error al Modificar el Usuario");

            }
        }

        protected void Filtro()
        {
            string constr = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM USUARIOS where IDUsuarios = "+ tIDusarios.Text +""))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();
                        }
                    }
                }
            }



        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            Filtro();

        }
    }
}