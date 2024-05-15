using _20240507.Conexion;
using _20240507.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _20240507.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IPerfilRepository repository;
        private readonly IMapper mapper;
        public EstudianteController( IPerfilRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EstudianteReadDTO>> GetEstudiantes() {
            Console.WriteLine("Se obtienen estudiantes (mediante servicio Campus)");
            var estudiantes = repository.GetEstudiantes();
            return Ok(mapper.Map<IEnumerable<EstudianteReadDTO>>(estudiantes));
        }
    }
}
