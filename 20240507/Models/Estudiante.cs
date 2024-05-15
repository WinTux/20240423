using System.ComponentModel.DataAnnotations;

namespace _20240507.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int fId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        public string? Carrera { get; set; }
        [Required]
        public DateTime fecha_nac { get; set; }
        [MaxLength(60)]
        public string? direccion { get; set; }
        public ICollection<Perfil> perfiles { get; set; } = new List<Perfil>();
    }
}
