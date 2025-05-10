using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEduWeb
{
    public partial class ProgesoInformes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            SDSProgresEst.ConnectionString = Conexion.con;
            SDSRecomEst.ConnectionString = Conexion.con;

            if (Page.IsPostBack)
            {
                return;
            }

            CargarProgresoEstudiante();
            CargarRecomendacionesEstudiante();
        }

        private void CargarProgresoEstudiante()
        {
            SDSProgresEst.SelectCommand = "SELECT \r\n\t" +
                "A.Nombre NombreArea,\r\n\t" +
                "PE.ActividadesRealizadas\r\n" +
            "FROM ProgresoEstudiante PE\r\n" +
            "INNER JOIN Areas A ON PE.IdArea = A.IdArea\r\n" +
            $"WHERE PE.IdEstudiante = '{Session["IdEstudiantePadre"]}';";
            SDSProgresEst.DataBind();
            GWProgresEst.DataBind();
        }

        private void CargarRecomendacionesEstudiante()
        {
            SDSRecomEst.SelectCommand = "SELECT \r\n\t" +
                "CONCAT(D.Nombres, ' ', D.Apellidos) Docente,\r\n\t" +
                "A.Nombre NombreArea,\r\n\t" +
                "RA.Descripcion,\r\n\t" +
                "RA.Fecha\r\n" +
            "FROM RecomendacionesApoyo RA\r\n" +
            "INNER JOIN Areas A ON A.IdArea = RA.IdArea\r\n" +
            "INNER JOIN Docentes D ON D.IdDocente = RA.IdDocente\r\n" +
            $"WHERE RA.IdEstudiante = '{Session["IdEstudiantePadre"]}';";
            SDSRecomEst.DataBind();
            GWRecomEst.DataBind();
        }

        protected void GWProgresEst_PageIndexChanged(object sender, EventArgs e)
        {
            CargarProgresoEstudiante();
        }

        protected void GWRecomEst_PageIndexChanged(object sender, EventArgs e)
        {
            CargarRecomendacionesEstudiante();
        }

        protected void BtnGenReport_Click(object sender, EventArgs e)
        {
            // Consulta de datos básicos del estudiante
            string nombreEstudiante = "-";
            using (SqlConnection con = new SqlConnection(Conexion.con))
            {
                con.Open();
                string sql = "SELECT IdEstudiante, CONCAT(Nombres, ' ', Apellidos) AS Nombres FROM Estudiantes WHERE IdEstudiante = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Session["IdEstudiantePadre"]);
                    using (SqlDataReader rst = cmd.ExecuteReader())
                    {
                        if (rst.Read())
                        {
                            nombreEstudiante = rst["Nombres"].ToString();
                        }
                    }
                }
            }

            // Creamos el documento PDF
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                // Título
                doc.Add(new Paragraph("Reporte de Estudiante"));
                doc.Add(new Paragraph($"Estudiante: {nombreEstudiante} ({Session["IdEstudiantePadre"]})"));
                doc.Add(new Paragraph($"Fecha de generación: {DateTime.Now.ToShortDateString()}"));
                doc.Add(new Paragraph(" ")); // Espacio

                // Tabla 1: Progreso Estudiante
                doc.Add(new Paragraph("Progreso por Área"));
                doc.Add(new Paragraph(" ")); // Espacio
                PdfPTable table1 = new PdfPTable(2);
                table1.AddCell("Área");
                table1.AddCell("Actividades Realizadas");

                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sql = "SELECT A.Nombre AS NombreArea, PE.ActividadesRealizadas \r\n" +
                    "FROM ProgresoEstudiante PE \r\n" +
                    "INNER JOIN Areas A ON PE.IdArea = A.IdArea \r\n" +
                    "WHERE PE.IdEstudiante = @IdEst";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@IdEst", Session["IdEstudiantePadre"]);
                        using (SqlDataReader rst = cmd.ExecuteReader())
                        {
                            while (rst.Read())
                            {
                                table1.AddCell(rst["NombreArea"].ToString());
                                table1.AddCell(rst["ActividadesRealizadas"].ToString());
                            }
                        }
                    }
                    doc.Add(table1);
                    doc.Add(new Paragraph(" ")); // Espacio
                }

                // Tabla 2: Recomendaciones de Apoyo
                doc.Add(new Paragraph("Recomendaciones de Apoyo"));
                doc.Add(new Paragraph(" ")); // Espacio
                PdfPTable table2 = new PdfPTable(4);
                table2.AddCell("Docente");
                table2.AddCell("Área");
                table2.AddCell("Descripción");
                table2.AddCell("Fecha");

                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sql = "SELECT CONCAT(D.Nombres, ' ', D.Apellidos) Docente, A.Nombre AS NombreArea, RA.Descripcion, RA.Fecha \r\n" +
                    "FROM RecomendacionesApoyo RA \r\n" +
                    "INNER JOIN Areas A ON A.IdArea = RA.IdArea \r\n" +
                    "INNER JOIN Docentes D ON D.IdDocente = RA.IdDocente\r\n" +
                    "WHERE RA.IdEstudiante = @IdEst";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@IdEst", Session["IdEstudiantePadre"]);
                        using (SqlDataReader rst = cmd.ExecuteReader())
                        {
                            while (rst.Read())
                            {
                                table2.AddCell(rst["Docente"].ToString());
                                table2.AddCell(rst["NombreArea"].ToString());
                                table2.AddCell(rst["Descripcion"].ToString());
                                table2.AddCell(Convert.ToDateTime(rst["Fecha"]).ToShortDateString());
                            }
                        }
                    }
                    doc.Add(table2);
                }

                doc.Close();

                byte[] bytes = ms.ToArray();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=ReporteEstudiante.pdf");
                Response.OutputStream.Write(bytes, 0, bytes.Length);
                Response.Flush();
                Response.End();
            }
        }
    }
}