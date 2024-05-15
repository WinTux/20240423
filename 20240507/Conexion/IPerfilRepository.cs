using _20240507.Models;

namespace _20240507.Conexion
{
    public interface IPerfilRepository
    {
        // Para Estudiante
        IEnumerable<Estudiante> GetEstudiantes();
        void CrearEstudiante(Estudiante est);
        bool ExisteEstudiante(int id);

        // Para Perfil
        Perfil GetPerfil(int idPerfil, int idEstudiante);
        IEnumerable<Perfil> GetPerfilesDeEstudiante(int idEstudiante);
        void CrearPerfil(int IdEstudiante, Perfil perfil);

        bool ExisteEstudianteForaneo(int fid);
        bool Guardar();
    }
}
