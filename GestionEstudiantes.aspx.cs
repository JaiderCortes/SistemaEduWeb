using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEduWeb
{
    public partial class GestionEstudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            SDSAreas.ConnectionString = Conexion.con;
            SDSEstudiantes.ConnectionString = Conexion.con;
            SDSProgresEst.ConnectionString = Conexion.con;
            SDSRecomEst.ConnectionString = Conexion.con;

            if (Page.IsPostBack)
            {
                return;
            }

            LimpiarDatosEstudianteNuevo();
            LimpiarDatosEstudiante();
            CargarEstudiantes();
            DDLEstudiantes_SelectedIndexChanged(null, null);
        }

        private void CargarEstudiantes()
        {
            SDSEstudiantes.SelectCommand = "SELECT E.IdEstudiante, CONCAT(E.Nombres, ' ', E.Apellidos) Nombres FROM Estudiantes E ORDER BY E.Apellidos ASC;";
            SDSEstudiantes.DataBind();
            DDLEstudiantes.DataBind();
        }

        private void CargarAreas()
        {
            try
            {
                DDLAreas.Items.Clear();
                SDSAreas.SelectCommand = "SELECT * FROM Areas ORDER BY Nombre ASC;";
                SDSAreas.DataBind();
                DDLAreas.DataBind();
            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al cargar las áreas. {ex.Message}", "error");
            }
        }

        private void CargarProgresoEstudiante()
        {
            SDSProgresEst.SelectCommand = "SELECT \r\n\t" +
                "A.Nombre NombreArea,\r\n\t" +
                "PE.ActividadesRealizadas\r\n" +
            "FROM ProgresoEstudiante PE\r\n" +
            "INNER JOIN Areas A ON PE.IdArea = A.IdArea\r\n" +
            $"WHERE PE.IdEstudiante = '{DDLEstudiantes.SelectedValue}';";
            SDSProgresEst.DataBind();
            GWProgresEst.DataBind();
        }

        private void CargarRecomendacionesEstudiante()
        {
            SDSRecomEst.SelectCommand = "SELECT \r\n\t" +
                "A.Nombre NombreArea,\r\n\t" +
                "RA.Descripcion,\r\n\t" +
                "RA.Fecha\r\n" +
            "FROM RecomendacionesApoyo RA\r\n" +
            "INNER JOIN Areas A ON A.IdArea = RA.IdArea\r\n" +
            $"WHERE RA.IdEstudiante = '{DDLEstudiantes.SelectedValue}' AND RA.IdDocente = '{Session["IdUsuario"]}';";
            SDSRecomEst.DataBind();
            GWRecomEst.DataBind();
        }
        
        private void LimpiarDatosEstudiante()
        {
            TxtIdEstudiante.Text = "";
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            TxtFechNac.Text = "";

            SDSProgresEst.SelectCommand = "";
            SDSProgresEst.DataBind();
            GWProgresEst.DataBind();

            SDSRecomEst.SelectCommand = "";
            SDSRecomEst.DataBind();
            GWRecomEst.DataBind();
        }

        private void LimpiarDatosEstudianteNuevo()
        {
            TxtIdEstudianteNew.Text = "";
            TxtNombresNew.Text = "";
            TxtApellidosNew.Text = "";
            TxtFechNacNew.Text = "";
        }

        protected void DDLEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DDLEstudiantes.Text))
            {
                LimpiarDatosEstudiante();
                PnlDatosEstudiante.Visible = false;
                return;
            }

            string idEstudiante = DDLEstudiantes.SelectedValue;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sql = "SELECT Nombres, Apellidos, FechaNacimiento FROM Estudiantes WHERE IdEstudiante = @IdEstudiante;";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@IdEstudiante", System.Data.SqlDbType.NVarChar).Value = idEstudiante;
                        using(SqlDataReader rst = cmd.ExecuteReader())
                        {
                            if (rst.HasRows)
                            {
                                rst.Read();

                                TxtIdEstudiante.Text = idEstudiante;
                                TxtNombres.Text = rst["Nombres"].ToString();
                                TxtApellidos.Text = rst["Apellidos"].ToString();
                                TxtFechNac.Text = Convert.ToDateTime(rst["FechaNacimiento"]).ToString("yyyy-MM-dd");

                                CargarProgresoEstudiante();
                                CargarRecomendacionesEstudiante();
                                PnlDatosEstudiante.Visible = true;
                            }
                            else
                            {
                                AlertHelper.MostrarAlerta(this, "Atención", $"El estudiante no existe.", "warning");
                                PnlDatosEstudiante.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error cargando la información del estudiante. {ex.Message}", "error");
                PnlDatosEstudiante.Visible = false;
            }
        }

        protected void BtnNuevoEstudiante_Click(object sender, EventArgs e)
        {
            PnlNuevEst.Visible = true;
        }

        protected void BtnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtIdEstudianteNew.Text) || string.IsNullOrWhiteSpace(TxtIdEstudianteNew.Text))
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la identificación del estudiante.", "warning");
                return;
            }
            if (string.IsNullOrEmpty(TxtNombresNew.Text) || string.IsNullOrWhiteSpace(TxtNombresNew.Text))
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese los nombres del estudiante.", "warning");
                return;
            }
            if (string.IsNullOrEmpty(TxtApellidosNew.Text) || string.IsNullOrWhiteSpace(TxtApellidosNew.Text))
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese los apellidos del estudiante.", "warning");
                return;
            }
            if (string.IsNullOrEmpty(TxtFechNacNew.Text) || string.IsNullOrWhiteSpace(TxtFechNacNew.Text))
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la fecha de nacimiento del estudiante.", "warning");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sql = "INSERT INTO Estudiantes (IdEstudiante, Nombres, Apellidos, FechaNacimiento, Clave) " +
                        "VALUES (@IdEstudiante, @Nombres, @Apellidos, @FechaNacimiento, @Clave);";
                    using(SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@IdEstudiante", System.Data.SqlDbType.NVarChar).Value = TxtIdEstudianteNew.Text;
                        cmd.Parameters.Add("@Nombres", System.Data.SqlDbType.NVarChar).Value = TxtNombresNew.Text;
                        cmd.Parameters.Add("@Apellidos", System.Data.SqlDbType.NVarChar).Value = TxtApellidosNew.Text;
                        cmd.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(TxtFechNacNew.Text);
                        cmd.Parameters.Add("@Clave", System.Data.SqlDbType.NVarChar).Value = "12345";

                        cmd.ExecuteNonQuery();

                        AlertHelper.MostrarAlerta(this, "Atención", $"Estudiante creado exitosamente.", "success");
                        LimpiarDatosEstudianteNuevo();
                        CargarEstudiantes();
                        PnlNuevEst.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error creando el nuevo estudiante. {ex.Message}", "error");
            }

        }

        protected void BtnCancelGuardarNuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatosEstudianteNuevo();
            PnlNuevEst.Visible = false;
        }

        protected void BtnGuardarEst_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNombres.Text) || string.IsNullOrWhiteSpace(TxtNombres.Text))
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese los nombres del estudiante.", "warning");
                return;
            }
            if (string.IsNullOrEmpty(TxtApellidos.Text) || string.IsNullOrWhiteSpace(TxtApellidos.Text))
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese los apellidos del estudiante.", "warning");
                return;
            }
            if (string.IsNullOrEmpty(TxtFechNac.Text) || string.IsNullOrWhiteSpace(TxtFechNac.Text))
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la fecha de nacimiento del estudiante.", "warning");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sql = "UPDATE Estudiantes SET Nombres = @Nombres, Apellidos = @Apellidos, FechaNacimiento = @FechaNacimiento WHERE IdEstudiante = @IdEstudiante;";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@IdEstudiante", System.Data.SqlDbType.NVarChar).Value = TxtIdEstudiante.Text;
                        cmd.Parameters.Add("@Nombres", System.Data.SqlDbType.NVarChar).Value = TxtNombres.Text;
                        cmd.Parameters.Add("@Apellidos", System.Data.SqlDbType.NVarChar).Value = TxtApellidos.Text;
                        cmd.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(TxtFechNac.Text);

                        cmd.ExecuteNonQuery();

                        AlertHelper.MostrarAlerta(this, "Atención", $"Datos del estudiante actualizados exitosamente.", "success");
                    }
                }
            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error actualizando los datos del estudiante. {ex.Message}", "error");
            }
        }

        protected void BtnNuevRecom_Click(object sender, EventArgs e)
        {
            CargarAreas();
            PnlRecomApoyo.Visible = true;
        }

        protected void BtnGuardRecom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtObsRecom.Text) || string.IsNullOrWhiteSpace(TxtObsRecom.Text))
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la recomendación de apoyo para el estudiante.", "warning");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sql = "INSERT INTO RecomendacionesApoyo(IdDocente, IdEstudiante, IdArea, Descripcion) VALUES (@IdDocente, @IdEstudiante, @IdArea, @Descripcion);";
                    using(SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@IdDocente", SqlDbType.NVarChar).Value = Session["IdUsuario"];
                        cmd.Parameters.Add("@IdEstudiante", SqlDbType.NVarChar).Value = TxtIdEstudiante.Text;
                        cmd.Parameters.Add("@IdArea", SqlDbType.NVarChar).Value = DDLAreas.SelectedValue;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = TxtObsRecom.Text;
                        cmd.ExecuteNonQuery();

                        AlertHelper.MostrarAlerta(this, "Atención", $"Recomendación de apoyo agregada exitosamente.", "success");
                        
                        CargarRecomendacionesEstudiante();
                        TxtObsRecom.Text = "";
                        PnlRecomApoyo.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al agregar la recomendación de apoyo para el estudiante. {ex.Message}", "error");
            }

        }

        protected void BtnCancelGuardRecom_Click(object sender, EventArgs e)
        {
            PnlRecomApoyo.Visible = false;
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