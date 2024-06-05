using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class Local
    {
        [Key]
        public int IdLocal { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "La ciudad no puede tener más de 50 caracteres.")]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "La dirección no puede tener más de 200 caracteres.")]
        public string Direccion { get; set; }

        [Required]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres.")]
        public string Telefono { get; set; }

        [Required]
        public Responsable Responsable { get; set; }

        public List<Maquina> Maquinas { get; set; }

        public List<Socio> Socios { get; set; }
    }
}
