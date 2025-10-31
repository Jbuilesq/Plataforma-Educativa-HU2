using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;

namespace platform.Application.Services;

public class ProfesorService
{
    private readonly IRepository<Profesor> _repository;

    public ProfesorService(IRepository<Profesor> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Profesor>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Profesor> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Profesor profesor)
    {
        await _repository.CreateAsync(profesor);
        await _repository.SaveChangessAsync();
    }

    public void UpdateAsync(Profesor profesor)
    {
        _repository.UpdateAsync(profesor);
    }

    public void DeleteAsync(Profesor profesor)
    {
        _repository.DeleteAsync(profesor);
    }
}
