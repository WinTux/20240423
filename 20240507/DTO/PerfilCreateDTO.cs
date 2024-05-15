using System.ComponentModel.DataAnnotations;

namespace _20240507.DTO
{
    public class PerfilCreateDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string Lenguajes { get; set; }
    }
}
