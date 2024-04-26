using _20240423.DTO;
using _20240423.Models;
using _20240423.Repositorios;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _20240423.Controllers
{
    [ApiController]
    [Route("api/estudiante")] // https://localhost:1234/api/estudiante
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository repo;
        private readonly IMapper mapper;

        public EstudianteController(IEstudianteRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet] // https://localhost:1234/api/estudiante [GET]
        public ActionResult<IEnumerable<EstudianteReadDTO>> GetEstudiantes() {
            var ests = repo.GetEstudiantes();
            return Ok(mapper.Map<IEnumerable<EstudianteReadDTO>>(ests));
        }
        [HttpGet("{idest}")] // https://localhost:1234/api/estudiante/123 [GET]
        public ActionResult<EstudianteReadDTO> GetEstudianteById(int idest) {
            var est = repo.GetEstudianteById(idest);
            if(est != null)
                return Ok(mapper.Map<EstudianteReadDTO>(est));
            return NotFound();// 404
        }
    }
}
