using System.ComponentModel.DataAnnotations;

namespace _20240423.DTO
{
    public class EstudiantePublisherDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime fecha_nac { get; set; }
        public string tipoEvento {  get; set; } // atributo extra e informativo
    }
}
