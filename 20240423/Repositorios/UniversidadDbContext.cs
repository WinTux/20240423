using _20240423.Models;
using Microsoft.EntityFrameworkCore;

namespace _20240423.Repositorios
{
    public class UniversidadDbContext : DbContext
    {
        public DbSet<Estudiante> estudiantes { get; set; }
        public UniversidadDbContext( DbContextOptions<UniversidadDbContext> options) : base(options)
        {
            
        }
    }
}
