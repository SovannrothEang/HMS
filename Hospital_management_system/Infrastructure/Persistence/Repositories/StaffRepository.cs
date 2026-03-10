using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.Constants;
using Dapper;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class StaffRepository : DapperRepository<Staff>, IStaffRepository
{
    public StaffRepository(IDbConnectionFactory connectionFactory) 
        : base(connectionFactory, TableNames.Staffs)
    {
    }

    public async Task<IEnumerable<Staff>> GetAllWithDepartmentsAsync()
    {
        string sql = $@"
            SELECT s.*, 
                   d.department_id AS split_dept, d.*,
                   p.position_id AS split_pos, p.*
            FROM {TableNames.Staffs} s
            LEFT JOIN {TableNames.Departments} d ON s.department_id = d.department_id
            LEFT JOIN {TableNames.Positions} p ON s.position_id = p.position_id
            WHERE s.is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        var staffList = await connection.QueryAsync<Staff, Department, Position, Staff>(
            sql,
            (staff, department, position) =>
            {
                staff.Department = department;
                staff.Position = position;
                return staff;
            },
            splitOn: "split_dept,split_pos");

        return staffList;
    }

    public async Task<int> AddAsync(Staff staff)
    {
        staff.UpdatedAt = null;
        string sql = $@"
            INSERT INTO {TableNames.Staffs} (
                staff_id, code, firstname, lastname, dob, gender, 
                phonenumber, address, email, position_id, hired_date, 
                salary, department_id, is_active, is_deleted, created_at
            ) VALUES (
                @StaffId, @Code, @FirstName, @LastName, @DOB, @Gender, 
                @PhoneNumber, @Address, @Email, @PositionId, @HiredDate, 
                @Salary, @DepartmentId, @IsActive, @IsDeleted, @CreatedAt
            )";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, staff);
    }

    public async Task<int> UpdateAsync(Staff staff)
    {
        staff.UpdatedAt = DateTime.UtcNow.AddHours(7);
        string sql = $@"
            UPDATE {TableNames.Staffs} SET 
                firstname = @FirstName, 
                lastname = @LastName, 
                dob = @DOB, 
                gender = @Gender, 
                phonenumber = @PhoneNumber, 
                address = @Address, 
                email = @Email, 
                position_id = @PositionId, 
                hired_date = @HiredDate, 
                salary = @Salary, 
                department_id = @DepartmentId, 
                is_active = @IsActive, 
                updated_at = @UpdatedAt
            WHERE staff_id = @StaffId AND is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, staff);
    }

    public async Task<int> DeleteAsync(string code)
    {
        string sql = $"UPDATE {TableNames.Staffs} SET is_deleted = 1 WHERE code = @Code";
        
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, new { Code = code });
    }

    public override async Task<Staff?> GetByCodeAsync(string code)
    {
        string sql = $"SELECT * FROM {TableNames.Staffs} WHERE code = @Code AND is_deleted = 0";
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Staff>(sql, new { Code = code });
    }
}
