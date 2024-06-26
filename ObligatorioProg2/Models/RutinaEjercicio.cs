using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class RutinaEjercicio
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rutina")]
        public int RutinaId { get; set; }
        public Rutina Rutina { get; set; }

        [ForeignKey("Ejercicio")]
        public int EjercicioId { get; set; }
        public Ejercicio Ejercicio { get; set; }

        [ForeignKey("Maquina")]
        public int? MaquinaId { get; set; }
        public Maquina? Maquina { get; set; }
    }
}
