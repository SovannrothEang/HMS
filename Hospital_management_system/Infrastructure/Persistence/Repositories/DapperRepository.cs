using System.Data;
using Dapper;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public abstract class DapperRepository<T> where T : class
{
    protected readonly IDbConnectionFactory _connectionFactory;
    protected readonly string _tableName;

    protected DapperRepository(IDbConnectionFactory connectionFactory, string tableName)
    {
        _connectionFactory = connectionFactory;
        _tableName = tableName;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<T>($"SELECT * FROM {_tableName} WHERE is_deleted = 0");
    }

    public virtual async Task<T?> GetByCodeAsync(string code)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(
            $"SELECT * FROM {_tableName} WHERE code = @Code AND is_deleted = 0", 
            new { Code = code });
    }

    // Additional generic methods can be added here as needed
}
