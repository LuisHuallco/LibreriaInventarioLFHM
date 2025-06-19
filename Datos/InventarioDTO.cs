using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Libreria.Datos
{
    public class InventarioDTO
    {
        public int InventarioID { get; set; }
        public int LibroID { get; set; }
        public int Cantidad { get; set; }
        public string TituloLibro { get; set; } // solo para mostrar

        public InventarioDTO() { }

        public InventarioDTO(int inventarioID, int libroID, int cantidad, string tituloLibro)
        {
            InventarioID = inventarioID;
            LibroID = libroID;
            Cantidad = cantidad;
            TituloLibro = tituloLibro;
        }
    }
}