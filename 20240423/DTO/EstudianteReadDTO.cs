using System.ComponentModel.DataAnnotations;

namespace _20240423.DTO
{
    public class EstudianteReadDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Carrera { get; set; }
        public string? direccion { get; set; }
    }
}
