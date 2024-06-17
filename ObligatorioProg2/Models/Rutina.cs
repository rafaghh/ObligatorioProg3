namespace ObligatorioProg3.Models
{
    public class Rutina
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public int Calificacion { get; set; }

        public TipoRutina? TipoRutina { get; set; }

        public int idTipoRutina { get; set; }
    }
}
