using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Maquina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Local Local { get; set; }
        public DateTime FechaCompra { get; set; }
        public int PrecioCompra { get; set; }
        public int VidaUtil { get; set; }
        public int TipoMId { get; set; }
        public TipoMaquina? TipoMaquina { get; set; }
        public bool Disponible { get; set; }

    }
}
