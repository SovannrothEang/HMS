using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAllAsync();
    Task<IEnumerable<Doctor>> GetAllWithStaffsAsync();
    Task<Doctor?> GetByCodeAsync(string code);
    Task<int> AddAsync(Doctor doctor);
    Task<int> UpdateAsync(Doctor doctor);
    Task<int> DeleteAsync(string code);
    Task<Doctor?> GetByStaffIdAsync(string staffId);
}
