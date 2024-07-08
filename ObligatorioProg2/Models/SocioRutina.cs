using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class SocioRutina
    {
        [ForeignKey("Socio")]
        public int SocioId { get; set; }
        public Socio Socio { get; set; }

        [ForeignKey("Rutina")]
        public int RutinaId { get; set; }
        public Rutina Rutina { get; set; }

        [ForeignKey("Maquina")]
        public int MaquinaId { get; set; }
        public Maquina? Maquina { get; set; }

        public int Calificacion { get; set; }
    }
}
