using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Socio : Persona
    {
        [Display(Name = "Tipo de Socio")]
        [ForeignKey("TiposSocio")]
        public int TipoId { get; set; }
        public TipoSocio? TipoSocio { get; set; }



        [Display(Name = "Local")]
        [ForeignKey("Locales")]
        public int LocalId { get; set; }
        public Local? Local { get; set; }
    }
}

