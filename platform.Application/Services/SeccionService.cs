using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;

namespace platform.Application.Services;

public class SeccionService
{
    private readonly IRepository<Seccion> _repository;

    public SeccionService(IRepository<Seccion> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Seccion>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Seccion> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Seccion seccion)
    {
        await _repository.CreateAsync(seccion);
        await _repository.SaveChangessAsync();
    }

    public void UpdateAsync(Seccion seccion)
    {
        _repository.UpdateAsync(seccion);
    }

    public void DeleteAsync(Seccion seccion)
    {
        _repository.DeleteAsync(seccion);
    }
}