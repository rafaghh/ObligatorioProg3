using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Socio : Persona
    {
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
    }
}

