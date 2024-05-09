using _20240423.ComunicacionSync.Http;
using _20240423.Repositorios;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace _20240423
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            var puerto = builder.Configuration["DBpuerto"] ?? "1433";
            var servidor = builder.Configuration["DBservidor"] ?? "192.168.1.252";
            var usuario = builder.Configuration["DBusuario"] ?? "sa";
            var password = builder.Configuration["DBpassword"] ?? "123456ABCxyz";
            var ddbb = builder.Configuration["DB"] ?? "UniversidadX";
            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(s => s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            builder.Services.AddHttpClient<ICampusHistorialCliente, ImplHttpCampusHistorialCliente>();
            builder.Services.AddScoped<IEstudianteRepository, ImplEstudianteRepository>();
            builder.Services.AddDbContext<UniversidadDbContext>( op => op.UseSqlServer($"Server={servidor},{puerto};DataBase={ddbb};User={usuario};Password={password};TrustServerCertificate=True;Encrypt=False"));//builder.Configuration.GetConnectionString("una_conexion")
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
