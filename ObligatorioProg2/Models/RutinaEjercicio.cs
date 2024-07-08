using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class RutinaEjercicio
    {
        [ForeignKey("Rutina")]
        public int RutinaId { get; set; }
        public Rutina Rutina { get; set; }

        [ForeignKey("Ejercicio")]
        public int EjercicioId { get; set; }
        public Ejercicio Ejercicio { get; set; }
    }
}
