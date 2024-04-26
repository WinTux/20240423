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

            return context.estudiantes.ToList();
        }
        public Estudiante GetEstudianteById(int idEstudiante) {
            return context.estudiantes.FirstOrDefault(est => est.Id == idEstudiante); // select * from estudiante where Id = 7 limit 1
        }

        public void AddEstudiante(Estudiante est)
        {
            if (est == null)
                throw new ArgumentNullException(nameof(est));
            context.estudiantes.Add(est);
        }

        public bool Guardar()
        {
            return (context.SaveChanges() > -1);
        }
    }
}
// TODO: Crear DTO para la creacion de Estudiante