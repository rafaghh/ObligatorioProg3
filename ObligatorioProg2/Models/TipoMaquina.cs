using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class TipoMaquina
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la máquina es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre de la máquina no puede exceder los 100 caracteres")]
        [Display(Name = "Tipo de la Máquina", Prompt = "Cinta de correr")]
        public string MaquinaNombre { get; set; }

        [MaxLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        [Display(Name = "Descripción de la Máquina", Prompt = "Máquina para correr y caminar")]
        public string Descripcion { get; set; }

        public ICollection<Maquina> Maquinas { get; set; } = new List<Maquina>();
    }
}

