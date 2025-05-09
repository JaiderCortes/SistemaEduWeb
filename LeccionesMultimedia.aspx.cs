using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEduWeb
{
    public partial class LeccionesMultimedia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Page.IsPostBack)
            {
                return;
            }

            CargarContenidos();
        }

        private void CargarContenidos()
        {
            string relativePath = WebConfigurationManager.AppSettings["ServidorContenidos"];
            string folderPath = Server.MapPath(relativePath);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("NombreArea");
            dt.Columns.Add("NombreArchivo");
            dt.Columns.Add("TamañoKB");
            dt.Columns.Add("RutaCompleta");
            dt.Columns.Add("RutaRelativa");

            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                con.Open();
                string sql = "SELECT C.Id, C.RutaRecurso, A.Nombre AS NombreArea FROM ContenidosMultimedia C INNER JOIN Areas A ON A.IdArea = C.IdArea;";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string rutaRelativa = reader.GetString(1);
                            string nombreArea = reader.GetString(2);
                            string fileName = Path.GetFileName(rutaRelativa);
                            string fullPath = Server.MapPath(rutaRelativa);

                            FileInfo fi = new FileInfo(fullPath);
                            string sizeKB = fi.Exists ? (fi.Length / 1024).ToString("N0") : "N/A";

                            dt.Rows.Add(id, nombreArea, fileName, sizeKB, fullPath, ResolveUrl(rutaRelativa));
                        }
                    }
                }
            }

            GridLecciones.DataSource = dt;
            GridLecciones.DataBind();
        }

        protected void GridLecciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridLecciones.PageIndex = e.NewPageIndex;
            CargarContenidos();
        }
    }
}