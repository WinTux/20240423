using _20240423.Models;

namespace _20240423.Repositorios
{
    public interface IEstudianteRepository
    {
        IEnumerable<Estudiante> GetEstudiantes();
        Estudiante GetEstudianteById(int idest);
    }
}
