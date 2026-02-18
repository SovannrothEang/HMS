using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<IEnumerable<User>> GetAllWithStaffAsync();
    Task<User?> GetByCodeAsync(string code);
    Task<User?> GetByUsernameAsync(string username);
    Task<int> AddAsync(User user);
    Task<int> UpdateAsync(User user);
    Task<int> DeleteAsync(string code);
}
