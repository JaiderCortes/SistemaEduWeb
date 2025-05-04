using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SistemaEduWeb
{
    public class Conexion
    {
        public static string con = ConfigurationManager.ConnectionStrings["ConexionGeneral"].ToString();
    }
}