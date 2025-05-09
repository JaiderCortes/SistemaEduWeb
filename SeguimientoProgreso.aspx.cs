using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEduWeb
{
    public partial class SeguimientoProgreso : System.Web.UI.Page
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
            $"WHERE PE.IdEstudiante = '{Session["IdUsuario"]}';";
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
            $"WHERE RA.IdEstudiante = '{Session["IdUsuario"]}';";
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
    }
}