using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class TipoMaquina
    {
        [Key]
        public int IdTipoMaq { get; set; }

        [Required]
        public string MaquinaNombre { get; set; }
        public string Descripcion { get; set; }
    }
}

