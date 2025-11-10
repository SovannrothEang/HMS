using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class PatientRepository(AppDbContext context) : IPatientRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Patient>> GetAllWithDoctorAsync()
    {
        return await _context.Patients
            .AsNoTracking()
            .Include(p => p.Doctor)
            .ThenInclude(d => d.Staff)
            .ThenInclude(s => s.Department)
            .ToListAsync();
    }
}
