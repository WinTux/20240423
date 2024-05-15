using _20240507.ComunicacionAsync;
using _20240507.Conexion;
using _20240507.Eventos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace _20240507
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<CampusDbContext>(op => op.UseInMemoryDatabase("miDb"));
            builder.Services.AddScoped<IPerfilRepository, ImplPerfilRepository>();
            builder.Services.AddScoped<IProcesadorDeEventos, ProcesadorDeEventos>();
            builder.Services.AddHostedService<BusDeMensajesSuscriptor>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
