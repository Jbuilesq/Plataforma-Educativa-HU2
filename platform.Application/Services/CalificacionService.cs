using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;

namespace platform.Application.Services;

public class CalificacionService
{
    private readonly IRepository<Calificacion> _repository;

    public CalificacionService(IRepository<Calificacion> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Calificacion>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Calificacion> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Calificacion calificacion)
    {
        await _repository.CreateAsync(calificacion);
        await _repository.SaveChangessAsync();
    }

    public void UpdateAsync(Calificacion calificacion)
    {
        _repository.UpdateAsync(calificacion);
    }

    public void DeleteAsync(Calificacion calificacion)
    {
        _repository.DeleteAsync(calificacion);
    }
}