using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Maquina
    {
        [Key]
        public int IdMaquina { get; set; }

        [Required]
        public Local Local { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El precio de compra debe ser mayor que 0.")]
        public int PrecioCompra { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La vida útil debe ser mayor que 0.")]
        public int VidaUtil { get; set; }

        [Display(Name = "Tipo Maquina")]
        [Required(ErrorMessage = "El tipo de maquina es requerido")]
        [ForeignKey("TiposM")]
        public int TipoMId { get; set; }
        public TipoMaquina? TipoMaquina { get; set; }

        
        
        
        [Required]
        public bool Disponible { get; set; }

    }
}
