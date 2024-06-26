using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class Rutina
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }
        public int Calificacion { get; set; }

        [Display(Name = "Rutina")]
        [ForeignKey("TiposRutina")]
        public int? TipoRutinaId { get; set; }
        public TipoRutina? TipoRutina { get; set; }

        public ICollection<SocioRutina> SocioRutinas { get; set; } = new List<SocioRutina>();
        public ICollection<RutinaEjercicio> RutinaEjercicios { get; set; } = new List<RutinaEjercicio>();
    }
}
