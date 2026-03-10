using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.Constants;
using Dapper;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class UserRepository : DapperRepository<User>, IUserRepository
{
    public UserRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory, TableNames.Users)
    {
    }

    public async Task<IEnumerable<User>> GetAllWithStaffAsync()
    {
        string sql = $@"
            SELECT u.*, 
                   s.staff_id AS split_staff, s.*, 
                   d.department_id AS split_dept, d.*,
                   p.position_id AS split_pos, p.*
            FROM {TableNames.Users} u
            JOIN {TableNames.Staffs} s ON u.staff_id = s.staff_id
            LEFT JOIN {TableNames.Departments} d ON s.department_id = d.department_id
            LEFT JOIN {TableNames.Positions} p ON s.position_id = p.position_id
            WHERE u.is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        var userList = await connection.QueryAsync<User, Staff, Department, Position, User>(
            sql,
            (user, staff, department, position) =>
            {
                user.Staff = staff;
                if (user.Staff != null)
                {
                    user.Staff.Department = department;
                    user.Staff.Position = position;
                }
                return user;
            },
            splitOn: "split_staff,split_dept,split_pos");

        return userList;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        string sql = $"SELECT * FROM {TableNames.Users} WHERE username = @Username AND is_deleted = 0";
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });
    }

    public async Task<int> AddAsync(User user)
    {
        user.UpdatedAt = null;
        string sql = $@"
            INSERT INTO {TableNames.Users} (
                user_id, code, username, password, staff_id, 
                is_active, is_deleted, created_at
            ) VALUES (
                @UserId, @Code, @Username, @Password, @StaffId, 
                @IsActive, @IsDeleted, @CreatedAt
            )";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, user);
    }

    public async Task<int> UpdateAsync(User user)
    {
        user.UpdatedAt = DateTime.UtcNow.AddHours(7);
        string sql = $@"
            UPDATE {TableNames.Users} SET 
                username = @Username, 
                password = @Password, 
                staff_id = @StaffId, 
                is_active = @IsActive, 
                updated_at = @UpdatedAt
            WHERE user_id = @UserId AND is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, user);
    }

    public async Task<int> DeleteAsync(string code)
    {
        string sql = $"UPDATE {TableNames.Users} SET is_deleted = 1 WHERE code = @Code";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, new { Code = code });
    }

    public override async Task<User?> GetByCodeAsync(string code)
    {
        string sql = $"SELECT * FROM {TableNames.Users} WHERE code = @Code AND is_deleted = 0";
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Code = code });
    }
}
