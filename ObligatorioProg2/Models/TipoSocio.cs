using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class TipoSocio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de socio es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre del tipo de socio no puede exceder los 100 caracteres")]
        public string TipoNombre { get; set; }

        [MaxLength(500, ErrorMessage = "Los beneficios no pueden exceder los 500 caracteres")]
        public string Beneficios { get; set; }

        public ICollection<Socio> Socios { get; set; } = new List<Socio>();
    }
}

