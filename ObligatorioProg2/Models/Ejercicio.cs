using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Ejercicio
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        [ForeignKey("TiposMaquina")]
        public int? TipoMaquinaId { get; set; }
        public TipoMaquina? TipoMaquina { get; set; }

        public ICollection<RutinaEjercicio> RutinaEjercicios { get; set; } = new List<RutinaEjercicio>();
    }
}
