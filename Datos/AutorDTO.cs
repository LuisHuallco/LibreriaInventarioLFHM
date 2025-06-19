namespace Inventario_Libreria.Datos
{
    public class AutorDTO
    {
        public int AutorID { get; set; }
        public string Nombre { get; set; }

        public AutorDTO() { }

        public AutorDTO(int autorID, string nombre)
        {
            AutorID = autorID;
            Nombre = nombre;
        }
    }
}
