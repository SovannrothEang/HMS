using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Domain.Repositories;

public interface IPositionRepository
{
    Task<IEnumerable<Position>> GetAllAsync();
    Task<Position?> GetByCodeAsync(string code);
    Task<IEnumerable<Position>> GetByDepartmentIdAsync(string departmentId);
    Task<int> AddAsync(Position position);
    Task<int> UpdateAsync(Position position);
    Task<int> DeleteAsync(string code);
}
