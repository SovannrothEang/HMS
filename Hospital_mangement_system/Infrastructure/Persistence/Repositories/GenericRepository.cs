using Hospital_mangement_system.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital_mangement_system.Infrastructure.Persistence.Repositories;

public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T>
where T : class
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();
    public async Task<IEnumerable<T>> GetAllAsyc()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<T?> GetByIdAsyc(string id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<bool> UpdateAsync(string id, T entity)
    {
        _dbSet.Update(entity);
        return await _dbContext.SaveChangesAsync() is 1;
    }
    public async Task<bool> DeleteAsync(string id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
        return await _dbContext.SaveChangesAsync() is 1;
    }
}
