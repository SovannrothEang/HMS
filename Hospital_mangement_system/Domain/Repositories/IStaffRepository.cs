using Hospital_mangement_system.Domain.Entities;

namespace Hospital_mangement_system.Domain.Repositories;

public interface IStaffRepository : IGenericRepository<Staff>
{
    Task<Staff?> GetByCodeAsync(string code);
    Task<Staff?> GetByEmailAsync(string email);
}
