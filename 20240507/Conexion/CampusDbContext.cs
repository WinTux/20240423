using _20240507.Models;
using Microsoft.EntityFrameworkCore;

namespace _20240507.Conexion
{
    public class CampusDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public CampusDbContext(DbContextOptions<CampusDbContext> opciones):base(opciones)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>().HasMany(es => es.perfiles).WithOne(per => per.estudiante!).HasForeignKey(p => p.IdEstudiante);
            modelBuilder.Entity<Perfil>().HasOne(p => p.estudiante).WithMany(es => es.perfiles).HasForeignKey(p => p.IdEstudiante);
        }
    }
}
