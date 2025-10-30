namespace webEscuela.Domain.Entities
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int InscripcionId { get; set; }
        public Inscripcion? Inscripcion { get; set; }

        public decimal Nota { get; set; }
    }
}