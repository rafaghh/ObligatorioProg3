using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class SocioRutina
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Socio")]
        public int SocioId { get; set; }
        public Socio Socio { get; set; }

        [ForeignKey("Rutina")]
        public int RutinaId { get; set; }
        public Rutina Rutina { get; set; }

        public int Calificacion { get; set; }
    }
}
