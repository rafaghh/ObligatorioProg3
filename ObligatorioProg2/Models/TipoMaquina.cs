using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class TipoMaquina
    {
        [Key]
        public int IdTipoMaq { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre de la máquina debe tener entre 2 y 100 caracteres.")]
        public string MaquinaNombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres.")]
        public string Descripcion { get; set; }
    }
}

