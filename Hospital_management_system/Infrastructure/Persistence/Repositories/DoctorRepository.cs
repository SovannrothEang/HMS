using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.Constants;
using Dapper;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class DoctorRepository : DapperRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(IDbConnectionFactory connectionFactory) 
        : base(connectionFactory, TableNames.Doctors)
    {
    }

    public async Task<IEnumerable<Doctor>> GetAllWithStaffsAsync()
    {
        string sql = $@"
            SELECT d.*, 
                   d.[years_of_experience ] AS YearsOfExperience,
                   s.staff_id AS split_staff, s.*, 
                   dept.department_id AS split_dept, dept.*
            FROM {TableNames.Doctors} d
            JOIN {TableNames.Staffs} s ON d.staff_id = s.staff_id
            LEFT JOIN {TableNames.Departments} dept ON s.department_id = dept.department_id
            WHERE d.is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        var doctorList = await connection.QueryAsync<Doctor, Staff, Department, Doctor>(
            sql,
            (doctor, staff, department) =>
            {
                doctor.Staff = staff;
                if (doctor.Staff != null) {
                    doctor.Staff.Department = department;
                }
                return doctor;
            },
            splitOn: "split_staff,split_dept");

        return doctorList;
    }

    public async Task<int> AddAsync(Doctor doctor)
    {
        doctor.UpdatedAt = null;
        string sql = $@"
            INSERT INTO {TableNames.Doctors} (
                doctor_id, code, specialization, license_number, 
                [years_of_experience ], stopped_work, staff_id, 
                is_active, is_deleted, created_at
            ) VALUES (
                @DoctorId, @Code, @Specialization, @LicenseNumber, 
                @YearsOfExperience, @StoppedWork, @StaffId, 
                @IsActive, @IsDeleted, @CreatedAt
            )";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, doctor);
    }

    public async Task<int> UpdateAsync(Doctor doctor)
    {
        doctor.UpdatedAt = DateTime.UtcNow.AddHours(7);
        string sql = $@"
            UPDATE {TableNames.Doctors} SET 
                specialization = @Specialization, 
                license_number = @LicenseNumber, 
                [years_of_experience ] = @YearsOfExperience, 
                stopped_work = @StoppedWork, 
                staff_id = @StaffId, 
                is_active = @IsActive, 
                updated_at = @UpdatedAt
            WHERE doctor_id = @DoctorId AND is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, doctor);
    }

    public async Task<int> DeleteAsync(string code)
    {
        string sql = $"UPDATE {TableNames.Doctors} SET is_deleted = 1 WHERE code = @Code";
        
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, new { Code = code });
    }

    public override async Task<Doctor?> GetByCodeAsync(string code)
    {
        string sql = $"SELECT * FROM {TableNames.Doctors} WHERE code = @Code AND is_deleted = 0";
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Doctor>(sql, new { Code = code });
    }
}
