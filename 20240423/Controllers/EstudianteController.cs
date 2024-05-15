using _20240423.ComunicacionAsync;
using _20240423.ComunicacionSync.Http;
using _20240423.DTO;
using _20240423.Models;
using _20240423.Repositorios;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace _20240423.Controllers
{
    [ApiController]
    [Route("api/estudiante")] // https://localhost:1234/api/estudiante
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository repo;
        private readonly IMapper mapper;
        private readonly ICampusHistorialCliente campusHistorialCliente;
        private readonly IBusDeMensajesCliente busDeMensajesCliente;

        public EstudianteController(IEstudianteRepository repo, IMapper mapper, ICampusHistorialCliente campusHistorialCliente, IBusDeMensajesCliente busDeMensajesCliente)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.campusHistorialCliente = campusHistorialCliente;
            this.busDeMensajesCliente = busDeMensajesCliente;
        }

        [HttpGet] // https://localhost:1234/api/estudiante [GET]
        public ActionResult<IEnumerable<EstudianteReadDTO>> GetEstudiantes() {
            var ests = repo.GetEstudiantes();
            return Ok(mapper.Map<IEnumerable<EstudianteReadDTO>>(ests));
        }
        [HttpGet("{idest}", Name = "GetEstudianteById")] // https://localhost:1234/api/estudiante/123 [GET]
        public ActionResult<EstudianteReadDTO> GetEstudianteById(int idest) {
            var est = repo.GetEstudianteById(idest);
            if(est != null)
                return Ok(mapper.Map<EstudianteReadDTO>(est));
            return NotFound();// 404
        }
        [HttpPost] // https://localhost:1234/api/estudiante [POST]
        public async Task<ActionResult<EstudianteReadDTO>> setEstudiante(EstudianteCreateDTO estCreateDTO) {
            Estudiante estudiante = mapper.Map<Estudiante>(estCreateDTO);
            repo.AddEstudiante(estudiante);
            repo.Guardar();
            EstudianteReadDTO estRetorno = mapper.Map<EstudianteReadDTO>(estudiante);

            try { 
                await campusHistorialCliente.ComunicarseConCampus(estRetorno);
            }catch(Exception e) {
                Console.WriteLine($"Ocurrio un error al comunicarse con Campus de forma sincronizada: {e.Message}");
            }

            // Async
            try
            {
                var estudiantePublisherDTO = mapper.Map<EstudiantePublisherDTO>(estRetorno);
                estudiantePublisherDTO.tipoEvento = "estudiante_publicado";
                busDeMensajesCliente.PublicarNuevoEstudiante(estudiantePublisherDTO)
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocurrio un error al comunicarse con Campus de forma asincrona: {e.Message}");
            }

            return CreatedAtRoute(nameof(GetEstudianteById), new { idest = estudiante.Id}, estRetorno);
        }
        [HttpPut("{id}")] // https://localhost:1234/api/estudiante/123 [PUT]
        public ActionResult UpdateEstudiante(int id, EstudianteUpdateDTO estUpdateDTO) { 
            Estudiante estudiante = repo.GetEstudianteById(id);
            if (estudiante == null)
                return NotFound();
            mapper.Map(estUpdateDTO,estudiante);
            repo.Guardar();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult updateEstudiantePatch(int id, JsonPatchDocument<EstudianteUpdateDTO> estPatch) {
            Estudiante estudiante = repo.GetEstudianteById(id);
            if (estudiante == null)
                return NotFound();
            EstudianteUpdateDTO estParaPatch = mapper.Map<EstudianteUpdateDTO>(estudiante);
            estPatch.ApplyTo(estParaPatch, ModelState);
            if (!TryValidateModel(estParaPatch))
                return ValidationProblem(ModelState);
            mapper.Map(estParaPatch, estudiante);
            repo.UpdateEstudiante(estudiante);
            repo.Guardar();
            return NoContent();
        }
        [HttpDelete("{idParaEliminar}")]
        public ActionResult eliminarEstudiante(int idParaEliminar) {
            Estudiante estudiante = repo.GetEstudianteById(idParaEliminar);
            if (estudiante == null)
                return NotFound();
            repo.DeleteEstudiante(estudiante);
            repo.Guardar();
            return NoContent();
        }
    }
}
