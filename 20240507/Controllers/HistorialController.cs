using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _20240507.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        public HistorialController() { }
        [HttpPost]
        public ActionResult Post() {
            Console.WriteLine("Llega una peticion al servicio 20240507 (Campus)");
            return Ok("Respuesta exitosa desde el controlador Historial de Campus");
        }
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "valor 1", "valor 2" };
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "valor unico";
        }
    }
}
