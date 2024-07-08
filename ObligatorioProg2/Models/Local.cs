using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioProg3.Models
{
    public class Local
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        [Display(Name = "Nombre del local", Prompt = "Ingrese el nombre del local")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La ciudad es requerida")]
        [Display(Name = "Ciudad")]
        [ForeignKey("Ciudades")]
        public int CiudadId { get; set; }
        public Ciudad? Ciudad { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [MaxLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres")]
        [Display(Name = "Dirección", Prompt = "Avenida Siempre Viva 123")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [Phone(ErrorMessage = "El teléfono no tiene un formato válido")]
        [Display(Name = "Télefono", Prompt = "098123456")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El responsable es requerido")]
        [Display(Name = "Responsable")]
        [ForeignKey("Responsables")]
        public int ResponsableId { get; set; }
        public Responsable? Responsable { get; set; }

        public ICollection<Maquina> Maquinas { get; set; } = new List<Maquina>();
        public ICollection<Socio> Socios { get; set; } = new List<Socio>();
    }
}
