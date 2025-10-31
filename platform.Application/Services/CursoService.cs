using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;

namespace platform.Application.Services;

public class CursoService
{
    private readonly IRepository<Curso> _cursoRepository;
    private readonly IRepository<Seccion> _seccionRepository;

    public CursoService(IRepository<Curso> cursoRepository, IRepository<Seccion> seccionRepository)
    {
        _cursoRepository = cursoRepository;
        _seccionRepository = seccionRepository;
    }

    public async Task<IEnumerable<Curso>> GetAllAsync()
    {
        return await _cursoRepository.GetAllAsync();
    }

    public async Task<Curso> GetByIdAsync(int id)
    {
        return await _cursoRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Curso curso)
    {
        await _cursoRepository.CreateAsync(curso);
        await _cursoRepository.SaveChangessAsync();
    }

    public void UpdateAsync(Curso curso)
    {
        _cursoRepository.UpdateAsync(curso);
    }

    public async Task<bool> DeleteAsync(Curso curso)
    {
        // Verificar si el curso tiene secciones activas
        var secciones = await _seccionRepository.GetAllAsync();
        bool tieneSecciones = secciones.Any(s => s.CursoId == curso.Id);

        if (tieneSecciones)
        {
            // No se puede eliminar si tiene secciones
            return false;
        }

        _cursoRepository.DeleteAsync(curso);
        await _cursoRepository.SaveChangessAsync();
        return true;
    }
}
