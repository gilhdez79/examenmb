namespace WebApi.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebApi.Models;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            Database.Migrate();
        }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<TipoEstado> TipoEstados { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<TipoEstado>().HasData(
                new TipoEstado {Id=1, NombreEstado = "Por Hacer" },
                new TipoEstado {Id=2, NombreEstado = "En Progreso" },
                new TipoEstado {Id=3, NombreEstado = "Hercho" }

            );
        }

    }
}
