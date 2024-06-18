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

        public DateTime FechaCompra { get; set; }
        public int PrecioCompra { get; set; }
        public int VidaUtil { get; set; }

        [Display(Name = "Tipo Maquina")]
        [ForeignKey("TiposMaquina")]
        public int? TipoMaquinaId { get; set; }
        public TipoMaquina? TipoMaquina { get; set; }

        public bool Disponible { get; set; }
    }
}
