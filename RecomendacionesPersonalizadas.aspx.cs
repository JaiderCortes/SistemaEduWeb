using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEduWeb
{
    public partial class RecomendacionesPersonalizadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            SDSRecomEst.ConnectionString = Conexion.con;

            if (Page.IsPostBack)
            {
                return;
            }

            CargarRecomendacionesEstudiante();
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

        protected void GWRecomEst_PageIndexChanged(object sender, EventArgs e)
        {
            CargarRecomendacionesEstudiante();
        }
    }
}