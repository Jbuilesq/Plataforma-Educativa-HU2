namespace webEscuela.Domain.Entities
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public Estudiante? Estudiante { get; set; }

        public int SeccionId { get; set; }
        public Seccion? Seccion { get; set; }

        public DateTime FechaInscripcion { get; set; }

        public Calificacion? Calificacion { get; set; }
    }
}