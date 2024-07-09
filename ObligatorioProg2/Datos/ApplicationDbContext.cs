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

            modelBuilder.Entity<Local>()
                .HasOne(l => l.Responsable)
                .WithOne(r => r.Local)
                .HasForeignKey<Local>(l => l.ResponsableId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Responsable>()
                .HasOne(r => r.Local)
                .WithOne(l => l.Responsable)
                .HasForeignKey<Responsable>(r => r.LocalId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Responsable>().HasData(
                new Responsable { Id = 1, Nombre = "Juan Perez", Telefono = "099123456", Email = "juan.perez@example.com", LocalId = 1},
                new Responsable { Id = 2, Nombre = "Maria Gomez", Telefono = "099654321", Email = "maria.gomez@example.com", LocalId = 2}
            );

            modelBuilder.Entity<Local>().HasData(
                new Local { Id = 1, Nombre = "Gimnasio Central", CiudadId = 1, Direccion = "Calle Falsa 123", Telefono = "22001234", ResponsableId = 1 },
                new Local { Id = 2, Nombre = "Gimnasio Este", CiudadId = 2, Direccion = "Avenida Siempreviva 742", Telefono = "23004567", ResponsableId = 2 }
            );

            modelBuilder.Entity<Maquina>().HasData(
                new Maquina { Id = 1, LocalId = 1, TipoMaquinaId = 1, FechaCompra = new DateTime(2023, 4, 6), PrecioCompra = 1500, VidaUtil = 5, Disponible = true},
                new Maquina { Id = 2, LocalId = 2, TipoMaquinaId = 2, FechaCompra = new DateTime(2022, 3, 2), PrecioCompra = 1300, VidaUtil = 3, Disponible = false}
            );

            modelBuilder.Entity<Socio>().HasData(
                new Socio { Id = 1, Nombre = "Carlos Ramirez", Telefono = "098765432", Email = "carlos.ramirez@example.com", TipoId = 1, LocalId = 1 },
                new Socio { Id = 2, Nombre = "Ana Fernandez", Telefono = "097654321", Email = "ana.fernandez@example.com", TipoId = 2, LocalId = 2 }
            );

            modelBuilder.Entity<Rutina>().HasData(
                new Rutina { Id = 1, Descripcion = "Rutina de Salud Básica", TipoRutinaId = 1 },
                new Rutina { Id = 2, Descripcion = "Rutina de Competición Amateur", TipoRutinaId = 2 }
            );

            modelBuilder.Entity<Ejercicio>().HasData(
                new Ejercicio { Id = 1, Descripcion = "Correr en Cinta", TipoMaquinaId = 1 },
                new Ejercicio { Id = 2, Descripcion = "Pedaleo en Bicicleta", TipoMaquinaId = 2 }
            );

            modelBuilder.Entity<SocioRutina>().HasData(
                new SocioRutina { SocioId = 1, RutinaId = 1, Calificacion = 5 },
                new SocioRutina { SocioId = 2, RutinaId = 2, Calificacion = 4 }
            );

            modelBuilder.Entity<RutinaEjercicio>().HasData(
                new RutinaEjercicio { RutinaId = 1, EjercicioId = 1 },
                new RutinaEjercicio { RutinaId = 2, EjercicioId = 2 }
            );
        }

    }
}
