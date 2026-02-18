using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.Constants;
using Dapper;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class PatientRepository : DapperRepository<Patient>, IPatientRepository
{
    public PatientRepository(IDbConnectionFactory connectionFactory) 
        : base(connectionFactory, TableNames.Patients)
    {
    }

    public async Task<IEnumerable<Patient>> GetAllWithDoctorAsync()
    {
        string sql = $@"
            SELECT p.*, d.*, s.*, dept.*
            FROM {TableNames.Patients} p
            JOIN {TableNames.Doctors} d ON p.doctor_id = d.doctor_id
            JOIN {TableNames.Staffs} s ON d.staff_id = s.staff_id
            LEFT JOIN {TableNames.Departments} dept ON s.department_id = dept.department_id
            WHERE p.is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        var patientList = await connection.QueryAsync<Patient, Doctor, Staff, Department, Patient>(
            sql,
            (patient, doctor, staff, department) =>
            {
                patient.Doctor = doctor;
                if (patient.Doctor != null)
                {
                    patient.Doctor.Staff = staff;
                    if (patient.Doctor.Staff != null)
                    {
                        patient.Doctor.Staff.Department = department;
                    }
                }
                return patient;
            },
            splitOn: "doctor_id,staff_id,department_id");

        return patientList;
    }

    public async Task<int> AddAsync(Patient patient)
    {
        string sql = $@"
            INSERT INTO {TableNames.Patients} (
                patient_id, code, firstname, lastname, dob, gender, 
                phonenumber, address, email, sickness, doctor_id, 
                is_active, is_deleted, created_at
            ) VALUES (
                @PatientId, @Code, @FirstName, @LastName, @DOB, @Gender, 
                @PhoneNumber, @Address, @Email, @Sickness, @DoctorId, 
                @IsActive, @IsDeleted, @CreatedAt
            )";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, patient);
    }

    public async Task<int> UpdateAsync(Patient patient)
    {
        string sql = $@"
            UPDATE {TableNames.Patients} SET 
                firstname = @FirstName, 
                lastname = @LastName, 
                dob = @DOB, 
                gender = @Gender, 
                phonenumber = @PhoneNumber, 
                address = @Address, 
                email = @Email, 
                sickness = @Sickness, 
                doctor_id = @DoctorId, 
                is_active = @IsActive, 
                updated_at = @UpdatedAt
            WHERE patient_id = @PatientId AND is_deleted = 0";

        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, patient);
    }

    public async Task<int> DeleteAsync(string code)
    {
        string sql = $"UPDATE {TableNames.Patients} SET is_deleted = 1 WHERE code = @Code";
        
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, new { Code = code });
    }

    public override async Task<Patient?> GetByCodeAsync(string code)
    {
        string sql = $"SELECT * FROM {TableNames.Patients} WHERE code = @Code AND is_deleted = 0";
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Patient>(sql, new { Code = code });
    }
}
