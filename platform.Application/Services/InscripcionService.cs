using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;

namespace platform.Application.Services;

public class InscripcionService
{
    private readonly IRepository<Inscripcion> _inscripcionRepository;
        private readonly IRepository<Seccion> _seccionRepository;
        private readonly IRepository<Calificacion> _calificacionRepository;

        public InscripcionService(
            IRepository<Inscripcion> inscripcionRepository,
            IRepository<Seccion> seccionRepository,
            IRepository<Calificacion> calificacionRepository)
        {
            _inscripcionRepository = inscripcionRepository;
            _seccionRepository = seccionRepository;
            _calificacionRepository = calificacionRepository;
        }

        public async Task<IEnumerable<Inscripcion>> GetAllAsync()
        {
            return await _inscripcionRepository.GetAllAsync();
        }

        public async Task<Inscripcion> GetByIdAsync(int id)
        {
            return await _inscripcionRepository.GetByIdAsync(id);
        }

        public async Task<string> CreateAsync(Inscripcion inscripcion)
        {
            var seccion = await _seccionRepository.GetByIdAsync(inscripcion.SeccionId);
            var inscripciones = await _inscripcionRepository.GetAllAsync();

            // 1️⃣ Validar cupo máximo
            int inscritos = inscripciones.Count(i => i.SeccionId == seccion.Id);
            if (inscritos >= seccion.CupoMaximo)
            {
                return "No se puede inscribir, el cupo máximo ha sido alcanzado.";
            }

            // 2️⃣ Validar horario superpuesto
            var inscripcionesEstudiante = inscripciones
                .Where(i => i.EstudianteId == inscripcion.EstudianteId)
                .ToList();

            foreach (var ins in inscripcionesEstudiante)
            {
                var seccionExistente = await _seccionRepository.GetByIdAsync(ins.SeccionId);

                bool mismoDia = seccionExistente.Dia == seccion.Dia;
                bool seCruza = seccionExistente.HoraInicio < seccion.HoraFin &&
                               seccion.HoraFin > seccionExistente.HoraInicio;

                if (mismoDia && seCruza)
                {
                    return "No se puede inscribir, hay conflicto de horario.";
                }
            }

            await _inscripcionRepository.CreateAsync(inscripcion);
            await _inscripcionRepository.SaveChangessAsync();

            return "Inscripción creada correctamente.";
        }

        public async Task DeleteAsync(Inscripcion inscripcion)
        {
            // 3️⃣ Eliminar calificación asociada si existe
            var calificaciones = await _calificacionRepository.GetAllAsync();
            var calificacion = calificaciones.FirstOrDefault(c => c.InscripcionId == inscripcion.Id);

            if (calificacion != null)
            {
                _calificacionRepository.DeleteAsync(calificacion);
                await _calificacionRepository.SaveChangessAsync();
            }

            _inscripcionRepository.DeleteAsync(inscripcion);
            await _inscripcionRepository.SaveChangessAsync();
        }
    }
