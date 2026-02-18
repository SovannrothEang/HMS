using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Domain.Repositories;

public interface IStaffRepository
{
    Task<IEnumerable<Staff>> GetAllAsync();
    Task<IEnumerable<Staff>> GetAllWithDepartmentsAsync();
    Task<Staff?> GetByCodeAsync(string code);
    Task<int> AddAsync(Staff staff);
    Task<int> UpdateAsync(Staff staff);
    Task<int> DeleteAsync(string code);
}
