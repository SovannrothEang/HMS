using System.Linq.Expressions;

namespace Hospital_management_system.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(string id);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(string id, T entity);
    Task<bool> DeleteAsync(string id);
    Task<bool> ExistsAsync(string id);

    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
