using _20240423.Models;
using _20240423.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace _20240423.Controllers
{
    [ApiController]
    [Route("api/estudiante")] // https://localhost:1234/api/estudiante
    public class EstudianteController : ControllerBase
    {
        private readonly ImplEstudianteRepository repo = new ImplEstudianteRepository();
        [HttpGet] // https://localhost:1234/api/estudiante [GET]
        public ActionResult<IEnumerable<Estudiante>> GetEstudiantes() {
            var ests = repo.GetEstudiantes();
            return Ok(ests);
        }
        [HttpGet("{idest}")] // https://localhost:1234/api/estudiante/123 [GET]
        public ActionResult<Estudiante> GetEstudianteById(int idest) {
            var est = repo.GetEstudianteById(idest);
            return Ok(est);
        }
    }
}
