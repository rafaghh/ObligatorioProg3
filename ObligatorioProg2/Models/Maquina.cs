using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Maquina
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Local")]
        [ForeignKey("Locales")]
        public int? LocalId { get; set; }
        public Local? Local { get; set; }

        [Required(ErrorMessage = "La fecha de compra es requerida")]
        public DateTime FechaCompra { get; set; }

        [Required(ErrorMessage = "El precio de compra es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio de compra debe ser un valor positivo")]
        [Display(Name = "Precio de compra en USD", Prompt = "1500")]
        public int PrecioCompra { get; set; }

        [Required(ErrorMessage = "La vida útil es requerida")]
        [Range(0, int.MaxValue, ErrorMessage = "La vida útil debe ser un valor positivo")]
        [Display(Name = "Vida Útil", Prompt = "6")]
        public int VidaUtil { get; set; }

        public bool Disponible { get; set; }

        [Display(Name = "Tipo Maquina")]
        [ForeignKey("TiposMaquina")]
        public int? TipoMaquinaId { get; set; }
        public TipoMaquina? TipoMaquina { get; set; }

        public int CalcularVidaUtilRestante()
        {
            int añosUsados = DateTime.Now.Year - FechaCompra.Year;
            return VidaUtil - añosUsados;
        }
    }
}

