using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class TipoRutina
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public ICollection<Rutina> Rutinas { get; set; }
    }
}
