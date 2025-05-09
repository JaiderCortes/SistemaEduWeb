using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEduWeb
{
    public partial class ActividadesInteractivas : System.Web.UI.Page
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
        }

        protected void BtnProgMat_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sqlValida = $"SELECT * FROM ProgresoEstudiante WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 1;";
                    using (SqlCommand cmd = new SqlCommand(sqlValida, con))
                    {
                        using (SqlDataReader rstValida = cmd.ExecuteReader())
                        {
                            if (rstValida.HasRows)
                            {
                                rstValida.Close();
                                string sql = $"UPDATE ProgresoEstudiante SET ActividadesRealizadas = ActividadesRealizadas + 1 WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 1;";
                                using(SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                rstValida.Close();
                                string sql = $"INSERT INTO ProgresoEstudiante VALUES('{Session["IdUsuario"]}', 1, 1);";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            AlertHelper.MostrarAlerta(this, "Atención", "Se ha actualizado el progreso del estudiante en matemáticas.", "success");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al agregar la recomendación de apoyo de matemáticas para el estudiante. {ex.Message}", "error");
            }
        }

        protected void BtnProgSoc_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sqlValida = $"SELECT * FROM ProgresoEstudiante WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 2;";
                    using (SqlCommand cmd = new SqlCommand(sqlValida, con))
                    {
                        using (SqlDataReader rstValida = cmd.ExecuteReader())
                        {
                            if (rstValida.HasRows)
                            {
                                rstValida.Close();
                                string sql = $"UPDATE ProgresoEstudiante SET ActividadesRealizadas = ActividadesRealizadas + 1 WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 2;";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                rstValida.Close();
                                string sql = $"INSERT INTO ProgresoEstudiante VALUES('{Session["IdUsuario"]}', 2, 1);";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            AlertHelper.MostrarAlerta(this, "Atención", "Se ha actualizado el progreso del estudiante en sociales.", "success");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al agregar la recomendación de apoyo de sociales para el estudiante. {ex.Message}", "error");
            }
        }

        protected void BtnProgNat_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sqlValida = $"SELECT * FROM ProgresoEstudiante WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 3;";
                    using (SqlCommand cmd = new SqlCommand(sqlValida, con))
                    {
                        using (SqlDataReader rstValida = cmd.ExecuteReader())
                        {
                            if (rstValida.HasRows)
                            {
                                rstValida.Close();
                                string sql = $"UPDATE ProgresoEstudiante SET ActividadesRealizadas = ActividadesRealizadas + 1 WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 3;";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                rstValida.Close();
                                string sql = $"INSERT INTO ProgresoEstudiante VALUES('{Session["IdUsuario"]}', 3, 1);";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            AlertHelper.MostrarAlerta(this, "Atención", "Se ha actualizado el progreso del estudiante en naturales.", "success");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al agregar la recomendación de apoyo de naturales para el estudiante. {ex.Message}", "error");
            }
        }

        protected void BtnProgArt_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sqlValida = $"SELECT * FROM ProgresoEstudiante WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 4;";
                    using (SqlCommand cmd = new SqlCommand(sqlValida, con))
                    {
                        using (SqlDataReader rstValida = cmd.ExecuteReader())
                        {
                            if (rstValida.HasRows)
                            {
                                rstValida.Close();
                                string sql = $"UPDATE ProgresoEstudiante SET ActividadesRealizadas = ActividadesRealizadas + 1 WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 4;";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                rstValida.Close();
                                string sql = $"INSERT INTO ProgresoEstudiante VALUES('{Session["IdUsuario"]}', 4, 1);";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            AlertHelper.MostrarAlerta(this, "Atención", "Se ha actualizado el progreso del estudiante en artes.", "success");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al agregar la recomendación de apoyo de artes para el estudiante. {ex.Message}", "error");
            }
        }

        protected void BtnProgHum_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sqlValida = $"SELECT * FROM ProgresoEstudiante WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 5;";
                    using (SqlCommand cmd = new SqlCommand(sqlValida, con))
                    {
                        using (SqlDataReader rstValida = cmd.ExecuteReader())
                        {
                            if (rstValida.HasRows)
                            {
                                rstValida.Close();
                                string sql = $"UPDATE ProgresoEstudiante SET ActividadesRealizadas = ActividadesRealizadas + 1 WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 5;";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                rstValida.Close();
                                string sql = $"INSERT INTO ProgresoEstudiante VALUES('{Session["IdUsuario"]}', 5, 1);";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            AlertHelper.MostrarAlerta(this, "Atención", "Se ha actualizado el progreso del estudiante en humanidades.", "success");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al agregar la recomendación de apoyo de humanidades para el estudiante. {ex.Message}", "error");
            }
        }

        protected void BtnProgCast_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.con))
                {
                    con.Open();
                    string sqlValida = $"SELECT * FROM ProgresoEstudiante WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 6;";
                    using (SqlCommand cmd = new SqlCommand(sqlValida, con))
                    {
                        using (SqlDataReader rstValida = cmd.ExecuteReader())
                        {
                            if (rstValida.HasRows)
                            {
                                rstValida.Close();
                                string sql = $"UPDATE ProgresoEstudiante SET ActividadesRealizadas = ActividadesRealizadas + 1 WHERE IdEstudiante = '{Session["IdUsuario"]}' AND IdArea = 6;";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                rstValida.Close();
                                string sql = $"INSERT INTO ProgresoEstudiante VALUES('{Session["IdUsuario"]}', 6, 1);";
                                using (SqlCommand cmd2 = new SqlCommand(sql, con))
                                {
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            AlertHelper.MostrarAlerta(this, "Atención", "Se ha actualizado el progreso del estudiante en lengua castellana.", "success");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AlertHelper.MostrarAlerta(this, "Atención", $"Ocurrió un error al agregar la recomendación de apoyo de lengua castellana para el estudiante. {ex.Message}", "error");
            }
        }
    }
}