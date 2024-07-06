using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;

namespace ObligatorioProg3.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<SocioRutina> SocioRutinas { get; set; }
        public DbSet<RutinaEjercicio> RutinaEjercicios { get; set; }
        public DbSet<TipoMaquina> TiposMaquina { get; set; }
        public DbSet<TipoRutina> TiposRutina { get; set; }
        public DbSet<TipoSocio> TiposSocio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones de las relaciones
            modelBuilder.Entity<SocioRutina>()
                .HasKey(sr => new { sr.SocioId, sr.RutinaId });

            modelBuilder.Entity<Socio>()
                .HasOne(s => s.TipoSocio)
                .WithMany(ts => ts.Socios)
                .HasForeignKey(s => s.TipoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Socio>()
                .HasOne(s => s.Local)
                .WithMany(l => l.Socios)
                .HasForeignKey(s => s.LocalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SocioRutina>()
                .HasOne(sr => sr.Socio)
                .WithMany(s => s.SocioRutinas)
                .HasForeignKey(sr => sr.SocioId);

            modelBuilder.Entity<SocioRutina>()
                .HasOne(sr => sr.Rutina)
                .WithMany(r => r.SocioRutinas)
                .HasForeignKey(sr => sr.RutinaId);

            modelBuilder.Entity<RutinaEjercicio>()
                .HasKey(re => new { re.RutinaId, re.EjercicioId });

            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(re => re.Rutina)
                .WithMany(r => r.RutinaEjercicios)
                .HasForeignKey(re => re.RutinaId);

            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(re => re.Ejercicio)
                .WithMany(e => e.RutinaEjercicios)
                .HasForeignKey(re => re.EjercicioId);

            // Juego de datos iniciales
            modelBuilder.Entity<TipoSocio>().HasData(
                new TipoSocio { Id = 1, TipoNombre = "Estándar", Beneficios = "Acceso limitado a áreas generales" },
                new TipoSocio { Id = 2, TipoNombre = "Premium", Beneficios = "Acceso ilimitado a áreas generales" }
            );

            modelBuilder.Entity<TipoRutina>().HasData(
                new TipoRutina { Id = 1, Nombre = "Salud" },
                new TipoRutina { Id = 2, Nombre = "Competición amateur" },
                new TipoRutina { Id = 3, Nombre = "Competición profesional" }
            );

            modelBuilder.Entity<Ciudad>().HasData(
                new Ciudad { Id = 1, Nombre = "Montevideo" },
                new Ciudad { Id = 2, Nombre = "Colonia" }
            );

            modelBuilder.Entity<TipoMaquina>().HasData(
                new TipoMaquina { Id = 1, MaquinaNombre = "Cinta de correr", Descripcion = "Máquina para correr y caminar" },
                new TipoMaquina { Id = 2, MaquinaNombre = "Bicicleta estática", Descripcion = "Máquina para ejercicio cardiovascular" }
            );
        }

    }
}
