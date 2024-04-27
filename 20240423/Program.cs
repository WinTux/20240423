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

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(s => s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            builder.Services.AddScoped<IEstudianteRepository, ImplEstudianteRepository>();
            builder.Services.AddDbContext<UniversidadDbContext>( op => op.UseSqlServer(builder.Configuration.GetConnectionString("una_conexion")));
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
