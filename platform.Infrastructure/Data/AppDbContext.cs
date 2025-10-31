using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Curso (1) -> Seccion (N): impedir eliminar Curso si tiene Secciones (Restrict)
            modelBuilder.Entity<Seccion>()
                .HasOne(s => s.Curso)
                .WithMany(c => c.Secciones)
                .HasForeignKey(s => s.CursoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Inscripcion (1) -> Calificacion (1): cascade delete de Calificacion si se borra Inscripcion
            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Inscripcion)
                .WithOne(i => i.Calificacion)
                .HasForeignKey<Calificacion>(c => c.InscripcionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Estudiante - Inscripcion (N)
            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Estudiante)
                .WithMany(e => e.Inscripciones)
                .HasForeignKey(i => i.EstudianteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Seccion - Inscripcion (N)
            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Seccion)
                .WithMany(s => s.Inscripciones)
                .HasForeignKey(i => i.SeccionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Curso - Profesor (1-N)
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Profesor)
                .WithMany(p => p.Cursos)
                .HasForeignKey(c => c.ProfesorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Índice para detectar solapamiento rápido (consulta): Seccion (CursoId, Dia, HoraInicio, HoraFin)
            modelBuilder.Entity<Seccion>()
                .HasIndex(s => new { s.CursoId, s.Dia, s.HoraInicio, s.HoraFin });

            // Puedes añadir validaciones / tipos precisos (ej: precision en decimal Nota)
            modelBuilder.Entity<Calificacion>()
                .Property(c => c.Nota)
                .HasPrecision(5,2);
        }
    }
}
