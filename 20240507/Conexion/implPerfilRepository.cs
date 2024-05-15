using _20240507.Models;

namespace _20240507.Conexion
{
    public class ImplPerfilRepository : IPerfilRepository
    {
        private readonly CampusDbContext _context;
        public ImplPerfilRepository(CampusDbContext context)
        {
            _context = context;
        }
        // Para Estudiante
        public IEnumerable<Estudiante> GetEstudiantes()
        {
            return _context.Estudiantes.ToList();
        }
        public void CrearEstudiante(Estudiante est)
        {
            if (est == null)
                throw new ArgumentNullException(nameof(est));
            else
                _context.Estudiantes.Add(est);
        }
        public bool ExisteEstudiante(int id)
        {
            return _context.Estudiantes.Any(est => est.Id == id);
        }

        // Para Perfil
        public Perfil GetPerfil(int idPerfil, int idEstudiante)
        {
            return _context.Perfiles.Where(per=>per.Id == idPerfil && per.IdEstudiante == idEstudiante).FirstOrDefault();
        }
        public IEnumerable<Perfil> GetPerfilesDeEstudiante(int idEstudiante)
        {
            return _context.Perfiles.Where(p=>p.IdEstudiante==idEstudiante).OrderBy(p=>p.estudiante.Apellido);
        }
        public void CrearPerfil(int IdEstudiante, Perfil perfil)
        {
            if (perfil == null)
                throw new ArgumentNullException(nameof(perfil));
            else { 
                perfil.IdEstudiante = IdEstudiante;
                _context.Perfiles.Add(perfil);
            }

        }
        public bool Guardar()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ExisteEstudianteForaneo(int fid)
        {
            return _context.Estudiantes.Any(es=>es.fId == fid);
        }
    }
}
