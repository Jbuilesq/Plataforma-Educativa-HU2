using platform.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using webEscuela.Infrastructure.Data;

namespace platform.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly EscuelaDbContext _context;
    protected readonly DbSet<T> _dbSet;


    public Repository(EscuelaDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await  _dbSet.FindAsync(id); 
    }

    public async Task CreateAsync(T t)
    {
        await _dbSet.AddAsync(t);
        await _context.SaveChangesAsync();
    }

    public void UpdateAsync(T t)
    {
        _dbSet.Update(t);
    }

    public void DeleteAsync(T t)
    {
        _dbSet.Remove(t);
    }

    public Task SaveChangessAsync()
    {
        return _context.SaveChangesAsync();
    }
}

