using System.ComponentModel.DataAnnotations;

namespace _20240507.DTO
{
    public class EstudianteReadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? direccion { get; set; }
    }
}
