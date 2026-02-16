using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Domain.Repositories;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllAsync();
    Task<Department?> GetByCodeAsync(string code);
    Task<int> AddAsync(Department department);
    Task<int> UpdateAsync(Department department);
    Task<int> DeleteAsync(string code);
}
