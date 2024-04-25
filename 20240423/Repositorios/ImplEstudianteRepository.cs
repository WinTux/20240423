using _20240423.Models;

namespace _20240423.Repositorios
{
    public class ImplEstudianteRepository : IEstudianteRepository
    {
        private readonly UniversidadDbContext context;

        public ImplEstudianteRepository(UniversidadDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Estudiante> GetEstudiantes() {
            var estudiantes = new List<Estudiante> { 
                new Estudiante{ 
                    Id = 1,
                    Nombre = "Pepe",
                    Apellido = "Perales",
                    Carrera = "Informática"
                },
                new Estudiante{
                    Id = 2,
                    Nombre = "Samantha",
                    Apellido = "Rocha",
                    Carrera = "Ing. Sistemas"
                },
                new Estudiante{
                    Id = 3,
                    Nombre = "Ana",
                    Apellido = "Roca",
                    Carrera = "Fisica"
                }
            };
            return estudiantes;
        }
        public Estudiante GetEstudianteById(int idEstudiante) {
            return new Estudiante
            {
                Id = 1,
                Nombre = "Samantha",
                Apellido = "Rocha",
                Carrera = "Ing. Sistemas"
            };
        }
    }
}
