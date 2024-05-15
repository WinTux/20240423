using System.ComponentModel.DataAnnotations;

namespace _20240507.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string Lenguajes { get; set; }
        [Required]
        public int IdEstudiante {  get; set; } // para relacionarse con fId
        public Estudiante estudiante { get; set; } // para navegar entre entidades
    }
}
