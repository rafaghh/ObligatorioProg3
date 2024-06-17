using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class Local
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public int IdResponsable { get; set; }
        public Responsable? Responsable { get; set; }

        public List<Maquina> Maquinas { get; set; }
        public List<Socio> Socios { get; set; }
    }
}
