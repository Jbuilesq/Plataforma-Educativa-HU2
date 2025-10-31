using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;

namespace platform.Application.Services;

public class EstudianteService
{
    private readonly IRepository<Estudiante> _repository;

    public EstudianteService(IRepository<Estudiante> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Estudiante>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Estudiante> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Estudiante estudiante)
    {
        await _repository.CreateAsync(estudiante);
        await _repository.SaveChangessAsync();
    }

    public void UpdateAsync(Estudiante estudiante)
    {
        _repository.UpdateAsync(estudiante);
    }

    public void DeleteAsync(Estudiante estudiante)
    {
        _repository.DeleteAsync(estudiante);
    }
}
