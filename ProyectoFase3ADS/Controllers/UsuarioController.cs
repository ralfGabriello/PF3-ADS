using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFase2ADS.Models;
using System.Data.SqlClient;


namespace ProyectoFase2ADS.Controllers
{
    public class UsuarioController : Controller
    {

        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader dataReader;

        // GET: Usuario
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void ConnectionString() 
        {
            conexion.ConnectionString = "data source=DESKTOP-ULD1V4S\\JACK1; database=ProyectoFase2ADS; integrated security = SSPI;";
        }

        [HttpPost]
        public ActionResult Verify(Usuario usuario) 
        {
            ConnectionString(); 
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandText = "select * from tablaUsuario where Nombre='"+usuario.Nombre+"' and Password='"+usuario.Password+"'";
            dataReader = comando.ExecuteReader();
            if (dataReader.Read())
            {
                conexion.Close();
                return RedirectToAction("../tablaPadres/Index"); 
            }
            //return View("../Home/About"); Con una ruta.
            return View("Login");
        }
    }
}