using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class StaffRepository (AppDbContext context) : IStaffRepository
{
    private readonly AppDbContext _context = context;
    public async Task<IEnumerable<Staff>> GetAllWithDepartmentsAsync()
    {
        return await _context.Staffs
            .AsNoTracking()
            .Include(s => s.Department)
            .Where(e => EF.Property<bool>(e, "IsDeleted") == false)
            .ToListAsync();
    }
}
