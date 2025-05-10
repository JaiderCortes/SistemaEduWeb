using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEduWeb
{
    public partial class SiteMaster : MasterPage
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

            NombreUsuario.InnerText = Session["NombreUsuario"].ToString();
            Rol.InnerText = Session["Rol"].ToString();

            if (Session["Rol"].ToString() == "Estudiante")
            {
                BtnCargaContenidos.Visible = false; //DOCENTE
                BtnGestEst.Visible = false; //DOCENTE
                BtnReportesEst.Visible = false; //DOCENTE
                BtnProgresInforms.Visible = false; //PADRE
                BtnRecomendaciones.Visible = false; //PADRE
            }
            else if (Session["Rol"].ToString() == "Docente")
            {
                BtnLecMultimedia.Visible = false; //ESTUDIANTE
                BtnActsInterac.Visible = false; //ESTUDIANTE
                BtnSegProgres.Visible = false; //ESTUDIANTE
                BtnProgresInforms.Visible = false; //PADRE
                BtnRecomendaciones.Visible = false; //PADRE
                Rol.Attributes["class"] = Rol.Attributes["class"].Replace("text-bg-primary", "text-bg-success");
            }
            else if (Session["Rol"].ToString() == "Padre")
            {
                BtnLecMultimedia.Visible = false; //ESTUDIANTE
                BtnActsInterac.Visible = false; //ESTUDIANTE
                BtnSegProgres.Visible = false; //ESTUDIANTE
                BtnCargaContenidos.Visible = false; //DOCENTE
                BtnGestEst.Visible = false; //DOCENTE
                BtnReportesEst.Visible = false; //DOCENTE
                Rol.Attributes["class"] = Rol.Attributes["class"].Replace("text-bg-primary", "text-bg-warning");

                IdEstudiante.InnerText = $"Estudiante: {Session["IdEstudiantePadre"]}";
                IdEstudiante.Visible = true;
                RolEst.Visible = true;
            }

        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void BtnLecMultimedia_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeccionesMultimedia.aspx");
        }

        protected void BtnActsInterac_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActividadesInteractivas.aspx");
        }

        protected void BtnSegProgres_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguimientoProgreso.aspx");
        }

        protected void BtnCargaContenidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargaContenidos.aspx");
        }

        protected void BtnGestEst_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionEstudiantes.aspx");
        }

        protected void BtnReportesEst_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportesEstudiante.aspx");
        }

        protected void BtnProgresInforms_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgresoInformes.aspx");
        }

        protected void BtnRecomendaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecomendacionesPersonalizadas.aspx");
        }
    }
}