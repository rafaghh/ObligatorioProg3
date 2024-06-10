using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;

namespace ObligatorioProg3.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {

        }

        public DbSet<Local> Local { get; set; }
        public DbSet<Socio> Socio { get; set; }
        public DbSet<TipoSocio> TipoSocio { get; set; }
        public DbSet<TipoMaquina> TipoMaquina { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
    }
}
