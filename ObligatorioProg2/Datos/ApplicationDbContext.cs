using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;

namespace ObligatorioProg3.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base (opciones)
        {

        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Responsable> Responsable { get; set; }
        public DbSet<Socio> Socio { get; set; }

    }
}
