using _20240507.Conexion;
using _20240507.DTO;
using _20240507.Models;
using AutoMapper;
using System.Text.Json;

namespace _20240507.Eventos
{
    enum TipoDeEvento
    {
        estudiante_publicado,
        desconocido
    }
    public class ProcesadorDeEventos : IProcesadorDeEventos
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IMapper mapper;

        public ProcesadorDeEventos(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.mapper = mapper;
        }
        public void ProcesarEvento(string msj)
        {
            var tipo = DeterminarEvento(msj);
            switch (tipo) {
                case TipoDeEvento.estudiante_publicado:
                    agregarEstudiante(msj);
                    break;
                case TipoDeEvento.desconocido:
                    break;
            }
        }

        private TipoDeEvento DeterminarEvento(string mensaje)
        {
            EventoDTO tipo = JsonSerializer.Deserialize<EventoDTO>(mensaje);
            switch (tipo.evento) {
                case "estudiante_publicado":
                    return TipoDeEvento.estudiante_publicado;
                default:
                    return TipoDeEvento.desconocido;
            }
        }

        

        private void agregarEstudiante(string mensajeEstudiantePublisher) {
            using (var scope = serviceScopeFactory.CreateScope()) {
                var repo = scope.ServiceProvider.GetRequiredService<IPerfilRepository>();
                var estudiantePublisherDTO = JsonSerializer.Deserialize<EstudiantePublisherDTO>(mensajeEstudiantePublisher);
                try {
                    var est = mapper.Map<Estudiante>(estudiantePublisherDTO);
                    if (!repo.ExisteEstudianteForaneo(est.fId)) {
                        repo.CrearEstudiante(est);
                        repo.Guardar();
                    }

                } catch (Exception e) {
                    Console.WriteLine($"Error al agregar estudiante a la DDBB: {e.Message}");
                }
            }
        }
    }
}
