using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Inventario_Libreria.Datos;

namespace Inventario_Libreria.Acceso_Datos
{
    public class LibroDAO
    {
        private Conexion conexion = new Conexion();

        public void InsertarLibro(string titulo, string genero, int anio, int autorID)
        {
            try
            {
                using (var conn = conexion.AbrirConexion())
                {
                    string sql = "CALL InsertarLibro(@titulo, @genero, @anio, @autorID);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@genero", genero);
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@autorID", autorID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar libro: " + ex.Message);
            }
        }

        public List<LibroDTO> ObtenerLibros()
        {
            List<LibroDTO> lista = new List<LibroDTO>();

            try
            {
                using (var conn = conexion.AbrirConexion())
                {
                    string sql = "CALL VerLibros();";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        LibroDTO libro = new LibroDTO
                        {
                            LibroID = reader.GetInt32("LibroID"),
                            Titulo = reader.GetString("Titulo"),
                            Genero = reader.GetString("Genero"),
                            AñoPublicacion = reader.GetInt32("AñoPublicacion"),
                            AutorID = reader.GetInt32("AutorID"),
                            NombreAutor = reader.GetString("Autor")
                        };
                        lista.Add(libro);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener libros: " + ex.Message);
            }

            return lista;
        }

        public void EliminarLibro(int libroID)
        {
            try
            {
                using (var conn = conexion.AbrirConexion())
                {
                    string sql = "CALL EliminarLibro(@id);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", libroID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar libro: " + ex.Message);
            }
        }
    }
}
