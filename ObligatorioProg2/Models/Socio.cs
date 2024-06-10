using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Socio : Persona
    {
        [Display(Name = "Tipo Socio")]
        [Required(ErrorMessage = "El tipo es requerido")]
        [ForeignKey("Tipos")]
        public int TipoId { get; set; }
        public TipoSocio? Tipo { get; set; }

        [Display(Name = "Local")]
        [Required(ErrorMessage = "El local es requerido")]
        [ForeignKey("Local")]
        public int LocalId { get; set; }

        public Local? Local { get; set; }
    }
}

