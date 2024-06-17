using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;

namespace ObligatorioProg3.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<TipoMaquina> TiposMaquina { get; set; }
        public DbSet<TipoRutina> TiposRutina { get; set; }
        public DbSet<TipoSocio> TiposSocio { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Local>()
                .HasOne(l => l.Responsable)
                .WithMany(r => r.Locales)
                .HasForeignKey(l => l.ResponsableId);

            modelBuilder.Entity<Socio>()
                .HasOne(s => s.Local)
                .WithMany(l => l.Socios)
                .HasForeignKey(s => s.LocalId);

            modelBuilder.Entity<Socio>()
                .HasOne(s => s.TipoSocio)
                .WithMany(ts => ts.Socios)
                .HasForeignKey(s => s.TipoId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ObligatorioProg3.Models.TipoSocio> TipoSocio { get; set; } = default!;
    }
}
