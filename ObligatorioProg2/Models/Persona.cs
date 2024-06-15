using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public abstract class Persona
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}

