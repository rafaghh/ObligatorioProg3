using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class TipoRutina
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        [Display(Name = "Nombre de la Rutina", Prompt = "Preparación campeonato")]
        public string Nombre { get; set; }

        public ICollection<Rutina> Rutinas { get; set; } = new List<Rutina>();
    }
}
