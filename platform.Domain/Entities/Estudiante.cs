namespace webEscuela.Domain.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}