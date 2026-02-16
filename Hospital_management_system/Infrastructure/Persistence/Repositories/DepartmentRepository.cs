using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Dapper;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class DepartmentRepository : DapperRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(IDbConnectionFactory connectionFactory) 
        : base(connectionFactory, "Departments")
    {
    }

    public async Task<int> AddAsync(Department department)
    {
        const string sql = @"
            INSERT INTO Departments (code, name, description, is_active, is_deleted, created_at)
            VALUES (@Code, @Name, @Description, @IsActive, @IsDeleted, @CreatedAt)";
        
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, department);
    }

    public async Task<int> UpdateAsync(Department department)
    {
        const string sql = @"
            UPDATE Departments 
            SET name = @Name, 
                description = @Description, 
                is_active = @IsActive, 
                updated_at = @UpdatedAt
            WHERE code = @Code AND is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, department);
    }

    public async Task<int> DeleteAsync(string code)
    {
        const string sql = "UPDATE Departments SET is_deleted = 1 WHERE code = @Code";
        
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, new { Code = code });
    }
}
