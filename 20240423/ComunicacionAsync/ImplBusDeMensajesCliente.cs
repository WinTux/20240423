using _20240423.DTO;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace _20240423.ComunicacionAsync
{
    public class ImplBusDeMensajesCliente : IBusDeMensajesCliente
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection connection;
        private readonly IModel canal;

        public ImplBusDeMensajesCliente(IConfiguration configuration)
        {
            this._configuration = configuration;
            ConnectionFactory factory = new ConnectionFactory() { 
                HostName = _configuration["Host_RabbitMQ"],
                Port = int.Parse(_configuration["Puerto_RabbitMQ"])
            };
            try {
                connection = factory.CreateConnection();
                canal = connection.CreateModel();
                canal.ExchangeDeclare(
                    exchange: "mi_exchange",
                    type: ExchangeType.Fanout
                );
                connection.ConnectionShutdown += RabbitMQ_evento_shutdown;
            }
            catch (Exception e) {
                Console.WriteLine($"Error al tratar de establecer conexion con RabbitMQ: {e.Message}");
            }
        }
        public void RabbitMQ_evento_shutdown(object sender, ShutdownEventArgs args) {
            Console.WriteLine("Se desconecta de RabbitMQ y algo podria ejecutarse ahora");
            // Codigo de interes
        }

        public void PublicarNuevoEstudiante(EstudiantePublisherDTO estudiantePublisherDTO)
        {
            string mensaje = JsonSerializer.Serialize(estudiantePublisherDTO);
            if (connection.IsOpen)
                Enviar(mensaje);
            else
                Console.WriteLine("Nop se pudo enviar el mensaje al bus de mensajes RabbitMQ");
        }
        private void Enviar(string msj) {
            var cuerpo = Encoding.UTF8.GetBytes(msj);
            canal.BasicPublish(
                exchange: "mi_exchange",
                routingKey: "",
                basicProperties: null,
                body: cuerpo
            );
            Console.WriteLine("Se envio mensaje al bus de mensajes RabbitMQ");
        }
        private void Finalizar() {
            if (canal.IsOpen) {
                canal.Close();
                connection.Close();
            }
        }
    }
}
