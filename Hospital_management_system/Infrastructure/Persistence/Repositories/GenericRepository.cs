using Hospital_management_system.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T>
where T : class
{
    private readonly AppDbContext _dbContext = dbContext
        ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            return await _dbSet.AsNoTracking()
                .Where(e => EF.Property<bool>(e, "IsDeleted") == false)
                .ToListAsync() ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception($"Error retrieving all {typeof(T).Name}: {ex.Message}", ex);
        }
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        try
        {
            return await _dbSet.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving {typeof(T).Name} with ID {id}: {ex.Message}", ex);
        }
    }
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
    public async Task<T> CreateAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error adding {typeof(T).Name}: {ex.Message}", ex);
        }
    }
    public async Task<bool> UpdateAsync(string id, T entity)
    {
        try
        {
            var existing = await _dbSet.FindAsync(id)
                ?? throw new Exception($"{typeof(T).Name} with ID {id} not found");

            _dbContext.Entry(existing).CurrentValues.SetValues(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating {typeof(T).Name}: {ex.Message}", ex);
        }
    }
    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            var existing = await _dbSet.FindAsync(id)
                ?? throw new Exception($"{typeof(T).Name} with ID {id} not found");

            _dbContext.Entry(existing).Property("IsDeleted").CurrentValue = true;

            return await _dbContext.SaveChangesAsync() > 0;
            //var entity = await _dbSet.FindAsync(id);
            //if (entity is null) return false;
            //_dbSet.Remove(entity);
            //return await _dbContext.SaveChangesAsync() != 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting {typeof(T).Name} with ID {id}: {ex.Message}", ex);
        }
    }

    public async Task<bool> ExistsAsync(string id)
    {
        try
        {
            return await _dbSet.FindAsync(id) != null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error checking existence of {typeof(T).Name} with ID {id}: {ex.Message}", ex);
        }
    }
}
