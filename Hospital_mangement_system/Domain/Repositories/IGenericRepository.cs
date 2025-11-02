using System.Linq.Expressions;

namespace Hospital_mangement_system.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsyc();
    Task<T?> GetByIdAsyc(string id);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
