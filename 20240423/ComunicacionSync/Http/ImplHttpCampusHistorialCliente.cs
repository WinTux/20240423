using _20240423.DTO;
using System.Text;
using System.Text.Json;

namespace _20240423.ComunicacionSync.Http
{
    public class ImplHttpCampusHistorialCliente : ICampusHistorialCliente
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        public ImplHttpCampusHistorialCliente(HttpClient httpClient, IConfiguration configuration) { 
            this.httpClient = httpClient;
            this.configuration = configuration;
        }
        public async Task ComunicarseConCampus(EstudianteReadDTO est)
        {
            StringContent cuerpoHttp = new StringContent(JsonSerializer.Serialize(est), Encoding.UTF8, "application/json");
            var respuesta = await httpClient.PostAsync($"{configuration["CampusService"]}/api/Historial", cuerpoHttp);

            if (respuesta.IsSuccessStatusCode)
                Console.WriteLine("Envio de POST sincronizado hacia el servicio Campus tuvo exito.");
            else
                Console.WriteLine("Envio de POST sincronizado hacia el servicio Campus NO tuvo exito.");
        }
    }
}
