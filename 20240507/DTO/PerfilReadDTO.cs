using System.ComponentModel.DataAnnotations;

namespace _20240507.DTO
{
    public class PerfilReadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Lenguajes { get; set; }
        public int IdEstudiante { get; set; }
    }
}
