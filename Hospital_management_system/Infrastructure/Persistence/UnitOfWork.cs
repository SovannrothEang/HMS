using System.Data;

namespace Hospital_management_system.Infrastructure.Persistence;

public interface IUnitOfWork : IDisposable
{
    IDbTransaction BeginTransaction();
    void Commit();
    void Rollback();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    public UnitOfWork(IDbConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
    }

    public IDbTransaction BeginTransaction()
    {
        _transaction = _connection.BeginTransaction();
        return _transaction;
    }

    public void Commit()
    {
        _transaction?.Commit();
        DisposeTransaction();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        DisposeTransaction();
    }

    public void Dispose()
    {
        DisposeTransaction();
        _connection.Dispose();
    }

    private void DisposeTransaction()
    {
        _transaction?.Dispose();
        _transaction = null;
    }
}
