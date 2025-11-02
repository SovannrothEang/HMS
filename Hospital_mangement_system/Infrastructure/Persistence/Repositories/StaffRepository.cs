using Hospital_mangement_system.Domain.Entities;
using Hospital_mangement_system.Domain.Repositories;
using System.Linq.Expressions;

namespace Hospital_mangement_system.Infrastructure.Persistence.Repositories;

public class StaffRepository : IStaffRepository
{
    public Task<Staff?> GetByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }
    public Task<Staff?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }
}
