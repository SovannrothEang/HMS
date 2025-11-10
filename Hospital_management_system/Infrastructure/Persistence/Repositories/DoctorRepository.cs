using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class DoctorRepository (AppDbContext context) : IDoctorRepository
{
    private readonly AppDbContext _context = context;
    public async Task<IEnumerable<Doctor>> GetAllWithStaffsAsync()
    {
        return await _context.Doctors
            .Include(d => d.Staff)
            .ThenInclude(s => s.Department)
            .Where(e => EF.Property<bool>(e, "IsDeleted") == false)
            .ToListAsync();
    }
}