using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Domain.Repositories;

public interface IStaffRepository
{
    Task<Staff?> GetByCodeAsync(string code);
    Task<Staff?> GetByEmailAsync(string email);
}
