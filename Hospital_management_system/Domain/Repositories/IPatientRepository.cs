using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Domain.Repositories;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetAllAsync();
    Task<IEnumerable<Patient>> GetAllWithDoctorAsync();
    Task<Patient?> GetByCodeAsync(string code);
    Task<int> AddAsync(Patient patient);
    Task<int> UpdateAsync(Patient patient);
    Task<int> DeleteAsync(string code);
    Task<bool> HasActivePatientsAsync(string doctorId);
}
