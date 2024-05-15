using _20240507.Conexion;
using _20240507.DTO;
using _20240507.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _20240507.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository repository;
        private readonly IMapper mapper;
        public PerfilController(IPerfilRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PerfilReadDTO>> GetPerfilesDeEstudiante(int IdEstudiante)
        {
            Console.WriteLine($"Se obtienen perfiles de estudiante {IdEstudiante} (mediante servicio Campus)");
            if (!repository.ExisteEstudiante(IdEstudiante))
                return NotFound();
            var perfiles = repository.GetPerfilesDeEstudiante(IdEstudiante);
            return Ok(mapper.Map<IEnumerable<PerfilReadDTO>>(perfiles));
        }

        [HttpGet("{IdPerfil}", Name= "GetPerfilDeEstudiante")] //http://localhost:1234/api/Perfil/123/321
        public ActionResult<IEnumerable<PerfilReadDTO>> GetPerfilDeEstudiante(int IdEstudiante, int IdPerfil)
        {
            Console.WriteLine($"Se obtienen el perfil {IdPerfil} del estudiante {IdEstudiante} (mediante servicio Campus)");
            if (!repository.ExisteEstudiante(IdEstudiante))
                return NotFound();
            var perfil = repository.GetPerfil(IdPerfil,IdEstudiante);
            if(perfil == null)
                return NotFound();
            return Ok(mapper.Map<PerfilReadDTO>(perfil));
        }
        [HttpPost]
        public ActionResult<PerfilReadDTO> CrearPerfilParaEstudiante(int IdEstudiante, PerfilCreateDTO perfilDTO) {
            Console.WriteLine($"Se crea un perfil para el estudiante {IdEstudiante} (mediante servicio Campus)");
            if (!repository.ExisteEstudiante(IdEstudiante))
                return NotFound();
            Perfil perfil = mapper.Map<Perfil>(perfilDTO);
            repository.CrearPerfil(IdEstudiante, perfil);
            repository.Guardar();
            var perfilReadDTO = mapper.Map<PerfilReadDTO>(perfil);
            return CreatedAtRoute(nameof(GetPerfilDeEstudiante), new { IdEstudiante = IdEstudiante, IdPerfil = perfilReadDTO.Id}, perfilReadDTO);
        }
    }
}
