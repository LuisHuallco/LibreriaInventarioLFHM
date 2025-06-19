using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Libreria.Datos
{
    public class LibroDTO
    {
        public int LibroID { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AñoPublicacion { get; set; }
        public int AutorID { get; set; }
        public string NombreAutor { get; set; } // Solo para mostrar en DataGridView

        public LibroDTO() { }

        public LibroDTO(int libroID, string titulo, string genero, int año, int autorID, string nombreAutor)
        {
            LibroID = libroID;
            Titulo = titulo;
            Genero = genero;
            AñoPublicacion = año;
            AutorID = autorID;
            NombreAutor = nombreAutor;
        }
    }
}

