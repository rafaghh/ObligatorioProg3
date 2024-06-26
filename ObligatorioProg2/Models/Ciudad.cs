using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public ICollection<Local> Locales { get; set; } = new List<Local>();
    }
}
