using System.ComponentModel.DataAnnotations;

namespace _20240423.DTO
{
    public class EstudianteUpdateDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        public string? Carrera { get; set; }
        public string? direccion { get; set; }
    }
}
