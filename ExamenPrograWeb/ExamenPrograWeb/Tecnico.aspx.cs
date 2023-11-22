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
    public partial class Tecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM TECNICOS"))
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

        
        protected void Button1_Click1(object sender, EventArgs e)
        {
            int retorno = Clases.Tecnicos.Agregar(tNombre.Text, tEspecialidad.Text);
            if (retorno > 0)
            {
                alertas("Tecnico Agregado");
                LlenarGrid();
            }
            else
            {
                alertas("Error al Agregar el Tecnico");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int retorno = Clases.Tecnicos.Borrar(tIDtecnicos.Text);
            if (retorno > 0)
            {
                alertas("Tecnico Borrado");
                LlenarGrid();
            }
            else
            {
                alertas("Error al Borrado el Tecnico");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int retorno = Clases.Tecnicos.Modificar(tNombre.Text, tEspecialidad.Text, tIDtecnicos.Text);
            if (retorno > 0)
            {
                alertas("Tecnico Modificado");
                LlenarGrid();
            }
            else
            {
                alertas("Error al Modificar el Tecnico");

            }
        }

         protected void Filtro()
        {
            string constr = ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM USUARIOS where IDTecnicos = " + tIDtecnicos.Text +""))
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
