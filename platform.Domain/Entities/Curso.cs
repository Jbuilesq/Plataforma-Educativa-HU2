namespace webEscuela.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public int ProfesorId { get; set; }
        public Profesor? Profesor { get; set; }

        public ICollection<Seccion> Secciones { get; set; } = new List<Seccion>();
    }
}