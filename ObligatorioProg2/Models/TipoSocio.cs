using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class TipoSocio
    {
        [Key]
        public int IdTipoSocio { get; set; }

        [Required]
        public string TipoNombre { get; set; }
        public string Beneficios { get; set; }
    }
}

