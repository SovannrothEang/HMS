using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.Constants;
using Dapper;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class PositionRepository : DapperRepository<Position>, IPositionRepository
{
    public PositionRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory, TableNames.Positions)
    {
    }

    public override async Task<IEnumerable<Position>> GetAllAsync()
    {
        string sql = $@"
            SELECT p.*, d.*
            FROM {TableNames.Positions} p
            LEFT JOIN {TableNames.Departments} d ON p.department_id = d.department_id
            WHERE p.is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Position, Department, Position>(sql, (p, d) =>
        {
            p.Department = d;
            return p;
        }, splitOn: "department_id");
    }

    public async Task<IEnumerable<Position>> GetByDepartmentIdAsync(string departmentId)
    {
        string sql = $"SELECT * FROM {TableNames.Positions} WHERE department_id = @DepartmentId AND is_deleted = 0";
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Position>(sql, new { DepartmentId = departmentId });
    }

    public async Task<int> AddAsync(Position position)
    {
        position.UpdatedAt = null;
        string sql = $@"
            INSERT INTO {TableNames.Positions} (position_id, code, name, description, department_id, is_active, is_deleted, created_at)
            VALUES (@PositionId, @Code, @Name, @Description, @DepartmentId, @IsActive, @IsDeleted, @CreatedAt)";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, position);
    }

    public async Task<int> UpdateAsync(Position position)
    {
        position.UpdatedAt = DateTime.UtcNow.AddHours(7);
        string sql = $@"
            UPDATE {TableNames.Positions} 
            SET name = @Name, 
                description = @Description, 
                department_id = @DepartmentId,
                is_active = @IsActive, 
                updated_at = @UpdatedAt
            WHERE code = @Code AND is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, position);
    }

    public async Task<int> DeleteAsync(string code)
    {
        string sql = $"UPDATE {TableNames.Positions} SET is_deleted = 1 WHERE code = @Code";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, new { Code = code });
    }
}
