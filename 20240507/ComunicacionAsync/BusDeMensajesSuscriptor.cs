using _20240507.Eventos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace _20240507.ComunicacionAsync
{
    public class BusDeMensajesSuscriptor : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IProcesadorDeEventos procesador;
        private IConnection conexion;
        private IModel canal;
        private string cola;

        public BusDeMensajesSuscriptor(IConfiguration configuration, IProcesadorDeEventos procesador)
        {
            _configuration = configuration;
            this.procesador = procesador;
            IniciarRabbitMQ();
        }

        private void IniciarRabbitMQ()
        {
            var factory = new ConnectionFactory() { 
                HostName = _configuration["Host_RabbitMQ"],
                Port = int.Parse(_configuration["Puerto_RabbitMQ"])
            };
            conexion = factory.CreateConnection();
            canal = conexion.CreateModel();
            canal.ExchangeDeclare(
                exchange: "mi_exchange",
                type: ExchangeType.Fanout
            );
            cola = canal.QueueDeclare().QueueName;
            canal.QueueBind(
                queue: cola,
                exchange: "mi_exchange",
                routingKey: ""

            );
            conexion.ConnectionShutdown += RabbitMQ_evento_shutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumidor = new EventingBasicConsumer(canal);
            consumidor.Received += (modulo, eveArgs) => {
                Console.WriteLine("Un evento sucedio");
                var cuerpo = eveArgs.Body;
                var mensaje = Encoding.UTF8.GetString(cuerpo.ToArray());
                procesador.ProcesarEvento(mensaje);
            };
            canal.BasicConsume(
                    queue: cola,
                    autoAck: true,
                    consumer: consumidor
            );
            return Task.CompletedTask;
        }

        public void RabbitMQ_evento_shutdown(object sender, ShutdownEventArgs args) {
            Console.WriteLine("Se desconecta de RabbitMQ y algo podria ejecutarse");
        }

        public override void Dispose()
        {
            if (canal.IsOpen) {
                canal.Close();
                conexion.Close();
            }
            base.Dispose();
        }
    }
}
