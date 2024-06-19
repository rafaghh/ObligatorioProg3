using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Local
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        
        [Display(Name = "Ciudad")]
        [ForeignKey("Ciudades")]
        public int CiudadId { get; set; }
        public Ciudad? Ciudad { get; set; }


        public string Direccion { get; set; }
        public string Telefono { get; set; }


        [Display(Name = "Responsable")]
        [ForeignKey("Responsables")]
        public int ResponsableId { get; set; }
        public Responsable? Responsable { get; set; }


        public List<Maquina> Maquinas { get; set; } = new List<Maquina>();
        public List<Socio> Socios { get; set; } = new List<Socio>();
    }
}
