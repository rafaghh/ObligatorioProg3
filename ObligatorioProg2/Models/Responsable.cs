using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class Responsable : Persona
    {
        public ICollection<Local> Locales { get; set; } = new List<Local>();
    }
}

