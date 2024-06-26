using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class Ejercicio
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection<RutinaEjercicio> RutinaEjercicios { get; set; } = new List<RutinaEjercicio>();
    }
}
