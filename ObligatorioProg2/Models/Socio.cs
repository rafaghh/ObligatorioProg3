using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Socio : Persona
    {

        [Required(ErrorMessage = "El tipo de socio es requerido")]
        [Display(Name = "Tipo de Socio")]
        [ForeignKey("TiposSocio")]
        public int TipoId { get; set; }
        public TipoSocio? TipoSocio { get; set; }

        [Required(ErrorMessage = "El local es requerido")]
        [Display(Name = "Local")]
        [ForeignKey("Locales")]
        public int LocalId { get; set; }
        public Local? Local { get; set; }

        public ICollection<SocioRutina> SocioRutinas { get; set; } = new List<SocioRutina>();
    }
}

