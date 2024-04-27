using System.ComponentModel.DataAnnotations;

namespace _20240423.DTO
{
    public class EstudianteCreateDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        [Required]
        public DateTime fecha_nac { get; set; }
    }
}
