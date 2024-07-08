using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Responsable : Persona
    {
        [ForeignKey("Local")]
        public int? LocalId { get; set; }
        public Local? Local { get; set; }
    }
}

