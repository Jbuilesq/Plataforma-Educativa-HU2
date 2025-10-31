namespace platform.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T t);
    void UpdateAsync(T t);
    void DeleteAsync(T t);
    Task SaveChangessAsync();
}