using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;  // 👈 Importante

namespace webEscuela.Infrastructure.Data
{
    public class EscuelaDbContext : DbContext
    {
        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options)
            : base(options) { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
    }
}