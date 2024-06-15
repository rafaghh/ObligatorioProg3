using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Socio : Persona
    {
        public int TipoId { get; set; }
        public TipoSocio? Tipo { get; set; }
        public int LocalId { get; set; }
        public Local? Local { get; set; }
    }
}

