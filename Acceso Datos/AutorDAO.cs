using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Inventario_Libreria.Datos;

namespace Inventario_Libreria.Acceso_Datos
{
    public class AutorDAO
    {
        private Conexion conexion = new Conexion();

        public void InsertarAutor(string nombre)
        {
            try
            {
                using (var conn = conexion.AbrirConexion())
                {
                    string sql = "CALL InsertarAutor(@nombre);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar autor: " + ex.Message);
            }
        }

        public List<AutorDTO> ObtenerAutores()
        {
            List<AutorDTO> lista = new List<AutorDTO>();

            try
            {
                using (var conn = conexion.AbrirConexion())
                {
                    string sql = "CALL VerAutores();";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AutorDTO autor = new AutorDTO
                        {
                            AutorID = reader.GetInt32("AutorID"),
                            Nombre = reader.GetString("Nombre")
                        };
                        lista.Add(autor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener autores: " + ex.Message);
            }

            return lista;
        }

        public void EliminarAutor(int id)
        {
            try
            {
                using (var conn = conexion.AbrirConexion())
                {
                    string sql = "CALL EliminarAutor(@id);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar autor: " + ex.Message);
            }
        }
    }
}
