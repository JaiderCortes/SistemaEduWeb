using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEduWeb
{
    public partial class CargaContenidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            SDSAreas.ConnectionString = Conexion.con;

            if(Page.IsPostBack)
            {
                return;
            }

            CargarAreas();
            CargarContenidos();
        }

        private void CargarAreas()
        {
            try
            {
                SDSAreas.SelectCommand = "SELECT * FROM Areas ORDER BY Nombre ASC;";
                SDSAreas.DataBind();
                DDLAreas.DataBind();
            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al cargar las áreas. {ex.Message}", "error");
            }
        }

        protected void BtnNuevoContenido_Click(object sender, EventArgs e)
        {
            try
            {
                if (DDLAreas.Text == "")
                {
                    AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, seleccione el área.", "warning");
                    return;
                }

                if (FileContenido.HasFiles)
                {
                    if (FileContenido.PostedFile.ContentLength < 5 * 1024 * 1024)
                    {
                        string rutaContenidos = WebConfigurationManager.AppSettings["ServidorContenidos"];
                        string carpetaContenidos = Server.MapPath(rutaContenidos);

                        if (!Directory.Exists(carpetaContenidos))
                        {
                            Directory.CreateDirectory(carpetaContenidos);
                        }

                        string nombreArchivo = Path.GetFileName(FileContenido.FileName);
                        string rutaArchivo = Path.Combine(carpetaContenidos, nombreArchivo);
                        string rutaContenido = $"{rutaContenidos}/{nombreArchivo}";

                        FileContenido.SaveAs(rutaArchivo);

                        using (SqlConnection con = new SqlConnection(Conexion.con))
                        {
                            con.Open();
                            string sql = "INSERT INTO ContenidosMultimedia (IdArea, RutaRecurso) VALUES (@IdArea, @RutaRecurso);";
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = DDLAreas.SelectedValue;
                                cmd.Parameters.Add("@RutaRecurso", SqlDbType.NVarChar, 100).Value = rutaContenido;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        AlertHelper.MostrarAlerta(this, "Atención", $"Archivo {nombreArchivo} guardado correctamente.", "success");
                        CargarContenidos();
                    }
                    else
                    {
                        AlertHelper.MostrarAlerta(this, "Atención", $"El archivo seleccionado excede el límite permitido.", "warning");
                    }
                }
                else
                {
                    AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, seleccione un archivo para subir.", "warning");
                }
            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al guardar el contenido. {ex.Message}", "error");
            }
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

            GridViewArchivos.DataSource = dt;
            GridViewArchivos.DataBind();
        }

        protected void GridViewArchivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarArchivo")
            {
                try
                {
                    int idArchivo = Convert.ToInt32(e.CommandArgument);
                    string rutaCompleta = string.Empty;

                    using (SqlConnection con = new SqlConnection(Conexion.con))
                    {
                        con.Open();
                        // Obtener ruta del archivo
                        string sql = "SELECT RutaRecurso FROM ContenidosMultimedia WHERE Id = @Id";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@Id", idArchivo);
                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                rutaCompleta = Server.MapPath(result.ToString());

                                // Eliminar archivo físico
                                if (File.Exists(rutaCompleta))
                                    File.Delete(rutaCompleta);

                                // Eliminar registro en BD
                                string sqlDelete = "DELETE FROM ContenidosMultimedia WHERE Id = @Id";
                                using (SqlCommand deleteCmd = new SqlCommand(sqlDelete, con))
                                {
                                    deleteCmd.Parameters.AddWithValue("@Id", idArchivo);
                                    deleteCmd.ExecuteNonQuery();

                                    AlertHelper.MostrarAlerta(this, "Atención", $"Archivo eliminado correctamente.", "success");
                                }
                            }
                            else
                            {
                                AlertHelper.MostrarAlerta(this, "Atención", $"El archivo no existe en la base de datos.", "warning");
                            }
                        }
                    }
                    CargarContenidos();
                }
                catch (Exception ex)
                {
                    AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al eliminar el archivo. {ex.Message}", "error");
                }
            }
        }

        protected void GridViewArchivos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewArchivos.PageIndex = e.NewPageIndex;
            CargarContenidos();
        }
    }
}