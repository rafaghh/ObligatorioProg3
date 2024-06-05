using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Socio : Persona
    {
        [Key]
        public int IdSocio { get; set; }

        [Required]
        [Display(Name = "Tipo Socio")]
        public TipoSocio Tipo { get; set; }

        [Required]
        public Local Local { get; set; }

        [NotMapped]
        public string Nombre { get; set; } 

        [NotMapped]
        public string Telefono { get; set; } 

        [NotMapped]
        public string Email { get; set; } 

        public Socio(int idSocio, string nombre, string telefono, string email, TipoSocio tipo, Local local)
        {
            IdSocio = idSocio;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Tipo = tipo;
            Local = local;
        }
    }
}

