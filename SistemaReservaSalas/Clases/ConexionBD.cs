using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaReservaSalas.Clases
{
    public class ConexionBD
    {
        private MySqlConnection conexion;

        public ConexionBD()
        {
            string cs = null;
            try
            {
                cs = ConfigurationManager.ConnectionStrings["MySqlConnection"]?.ConnectionString;
            }
            catch { }
            if (string.IsNullOrEmpty(cs))
            {
                // fallback to a default local connection (update in App.config is recommended)
                cs = "Server=localhost;Database=reservasdb;Uid=root;Pwd=;"; 
            }
            conexion = new MySqlConnection(cs);
        }

        public MySqlConnection ObtenerConexion()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
            return conexion;
        }

        public void Conectar()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
        }

        public void Desconectar()
        {
            if (conexion != null && conexion.State != ConnectionState.Closed)
                conexion.Close();
        }
    }
}
