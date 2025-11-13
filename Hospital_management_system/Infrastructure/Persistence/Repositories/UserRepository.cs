using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class UserRepository (AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .Where(x => x.IsDeleted == false)
            .ToListAsync();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Where(x => x.IsDeleted == false)
            .FirstOrDefaultAsync(x => x.Username == username);
    }
}
