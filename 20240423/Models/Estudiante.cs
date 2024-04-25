using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20240423.Models
{
    [Table("Estudiante")]
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido {  get; set; }
        public string? Carrera { get; set; }
        [Required]
        public DateTime fecha_nac {  get; set; }
        [MaxLength(60)]
        public string? direccion {  get; set; }
    }
}
