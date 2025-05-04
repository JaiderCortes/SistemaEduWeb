using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEduWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnIngresoEstudiante_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtIdEstudiante.Text) || string.IsNullOrWhiteSpace(TxtIdEstudiante.Text))
                {
                    AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la identificación del estudiante.", "warning");
                    return;
                }
                if (string.IsNullOrEmpty(TxtPassEstudiante.Text) || string.IsNullOrWhiteSpace(TxtPassEstudiante.Text))
                {
                    AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la contraseña del estudiante.", "warning");
                    return;
                }
                string idEstudiante = TxtIdEstudiante.Text.Trim();
                string passEstudiante = TxtPassEstudiante.Text.Trim();

                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sql = $"SELECT TOP 1 * FROM Estudiantes WHERE IdEstudiante = '{idEstudiante}' AND Clave = '{passEstudiante}';";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader rst = cmd.ExecuteReader())
                        {
                            if (rst.HasRows)
                            {
                                rst.Read();
                                Session["IdUsuario"] = rst["IdEstudiante"];
                                Session["NombreUsuario"] = $"{rst["Nombres"]} {rst["Apellidos"]}";
                                Session["Rol"] = "Estudiante";
                                Response.Redirect("LeccionesMultimedia.aspx");
                            }
                            else
                            {
                                AlertHelper.MostrarAlerta(this, "Atención", $"Usuario o contraseña incorrectos.", "warning");
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Error", $"Ocurrió un error en el ingreso del estudiante. {ex.Message}", "error");
            }
        }

        protected void BtnIngresoDocente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtIdDocente.Text) || string.IsNullOrWhiteSpace(TxtIdDocente.Text))
                {
                    AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la identificación del docente.", "warning");
                    return;
                }
                if (string.IsNullOrEmpty(TxtPassDocente.Text) || string.IsNullOrWhiteSpace(TxtPassDocente.Text))
                {
                    AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la contraseña del docente.", "warning");
                    return;
                }
                string idDocente = TxtIdDocente.Text.Trim();
                string passDocente = TxtPassDocente.Text.Trim();

                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sql = $"SELECT TOP 1 * FROM Docentes WHERE IdDocente = '{idDocente}' AND Clave = '{passDocente}';";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader rst = cmd.ExecuteReader())
                        {
                            if (rst.HasRows)
                            {
                                rst.Read();
                                Session["IdUsuario"] = rst["IdDocente"];
                                Session["NombreUsuario"] = $"{rst["Nombres"]} {rst["Apellidos"]}";
                                Session["Rol"] = "Docente";
                                Response.Redirect("CargaContenidos.aspx");
                            }
                            else
                            {
                                AlertHelper.MostrarAlerta(this, "Atención", $"Usuario o contraseña incorrectos.", "warning");
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Error", $"Ocurrió un error en el ingreso del docente. {ex.Message}", "error");
            }
        }

        protected void BtnIngresoPadre_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtIdPadre.Text) || string.IsNullOrWhiteSpace(TxtIdPadre.Text))
                {
                    AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la identificación del padre de familia.", "warning");
                    return;
                }
                if (string.IsNullOrEmpty(TxtPassPadre.Text) || string.IsNullOrWhiteSpace(TxtPassPadre.Text))
                {
                    AlertHelper.MostrarAlerta(this, "Atención", $"Por favor, ingrese la contraseña del padre de familia.", "warning");
                    return;
                }
                string idPadre = TxtIdPadre.Text.Trim();
                string passPadre = TxtPassPadre.Text.Trim();

                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sql = $"SELECT TOP 1 * FROM Padres WHERE IdPadre = '{idPadre}' AND Clave = '{passPadre}';";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader rst = cmd.ExecuteReader())
                        {
                            if (rst.HasRows)
                            {
                                rst.Read();
                                Session["IdUsuario"] = rst["IdPadre"];
                                Session["NombreUsuario"] = $"{rst["Nombres"]} {rst["Apellidos"]}";
                                Session["IdEstudiantePadre"] = rst["IdEstudiante"];
                                Session["Rol"] = "Padre";
                                Response.Redirect("ProgesoInformes.aspx");
                            }
                            else
                            {
                                AlertHelper.MostrarAlerta(this, "Atención", $"Usuario o contraseña incorrectos.", "warning");
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Error", $"Ocurrió un error en el ingreso del docente. {ex.Message}", "error");
            }
        }
    }
}