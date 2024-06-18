using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class Rutina
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public int Calificacion { get; set; }


        [Display(Name = "Rutina")]
        [ForeignKey("TiposRutina")]
        public int? TipoRutinaId { get; set; }
        public TipoRutina? TipoRutina { get; set; }
    }
}
