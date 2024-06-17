namespace ObligatorioProg3.Models
{
    public class TipoRutina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Rutina> Rutinas { get; set; }
    }
}
