using System.ComponentModel.DataAnnotations;

namespace ObligatorioProg3.Models
{
    public class Responsable : Persona
    {
        [Key]
        public int IdResponsable { get; set; }

        public Responsable(int idResponsable, string nombre, string telefono)
        {
            IdResponsable = idResponsable;
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}

