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
        public DbSet<Persona> Personas { get; set; }
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

            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(re => re.Maquina)
                .WithMany()
                .HasForeignKey(re => re.MaquinaId);

            modelBuilder.Entity<Local>()
                .HasOne(l => l.Responsable)
                .WithMany(r => r.Locales)
                .HasForeignKey(l => l.ResponsableId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
