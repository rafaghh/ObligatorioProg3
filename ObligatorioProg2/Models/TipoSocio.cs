using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class TipoSocio
    {
        [Key]
        public int IdTipoSocio { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre del tipo de socio debe tener entre 2 y 100 caracteres.")]
        public string TipoNombre { get; set; }

        [StringLength(500, ErrorMessage = "Los beneficios no pueden tener más de 500 caracteres.")]
        public string Beneficios { get; set; }
    }
}

