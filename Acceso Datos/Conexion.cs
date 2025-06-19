using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Inventario_Libreria.Acceso_Datos
{
    internal class Conexion
    {
        private MySqlConnection conexion;

        private string cadenaConexion = "server=localhost;user id=root;password=123;database=libreria;";

        public MySqlConnection AbrirConexion()
        {
            try
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
