using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Ejercicio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(20, ErrorMessage = "La descripción no puede exceder los 20 caracteres")]
        [Display(Name = "Descripción", Prompt = "Breve descripción del ejercicio")]
        public string Descripcion { get; set; }

        [ForeignKey("TiposMaquina")]
        public int? TipoMaquinaId { get; set; }
        public TipoMaquina? TipoMaquina { get; set; }

        public ICollection<RutinaEjercicio> RutinaEjercicios { get; set; } = new List<RutinaEjercicio>();
    }
}
