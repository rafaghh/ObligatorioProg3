using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public abstract class Persona
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre del socio", Prompt = "Juan Perez")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Télefono del socio", Prompt = "091123456")]
        [Phone(ErrorMessage = "El teléfono no tiene un formato válido")]
        public string Telefono { get; set; }

        [Display(Name = "Email del socio", Prompt = "nombre@ejemplo.com")]
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string Email { get; set; }
    }
}

