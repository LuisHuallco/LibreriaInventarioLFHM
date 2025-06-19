using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Inventario_Libreria.Datos;

namespace Inventario_Libreria.Acceso_Datos
{
    public class InventarioDAO
    {
        private Conexion conexion = new Conexion();

        public void InsertarInventario(int libroID, int cantidad)
        {
            try
            {
                using (var conn = conexion.AbrirConexion())
                {
                    string sql = "CALL InsertarInventario(@libroID, @cantidad);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@libroID", libroID);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar inventario: " + ex.Message);
            }
        }

        public List<InventarioDTO> ObtenerInventario()
        {
            List<InventarioDTO> lista = new List<InventarioDTO>();

            try
            {
                using (var conn = conexion.AbrirConexion())
                {
                    string sql = "CALL VerInventario();";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        InventarioDTO item = new InventarioDTO
                        {
                            InventarioID = reader.GetInt32("InventarioID"),
                            LibroID = reader.GetInt32("LibroID"),
                            Cantidad = reader.GetInt32("Cantidad"),
                            TituloLibro = reader.GetString("Titulo")
                        };
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener inventario: " + ex.Message);
            }

            return lista;
        }

        public void EliminarInventario(int id)
        {
            try
            {
                using (var conn = conexion.AbrirConexion())
                {
                    string sql = "CALL EliminarInventario(@id);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar inventario: " + ex.Message);
            }
        }
    }
}
