using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class StaffRepository (AppDbContext context) : IStaffRepository
{
    private readonly AppDbContext _context = context;
    public async Task<Staff?> GetByCodeAsync(string code)
    {
        return await _context.Staffs
            .FirstOrDefaultAsync(s => s.Code == code);
    }

    public async Task<Staff?> GetByEmailAsync(string email)
    {
        return await _context.Staffs
            .FirstOrDefaultAsync(s => s.Email == email);
    }
}
