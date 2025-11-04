using Hospital_management_system.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class PatientRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;
    public async Task<IEnumerable<Patient>> GetActivePatientsAsync()
    {
        return await _context.Patients
            .Where(p => p.IsActive)
            .OrderBy(p => p.LastName)
            .ToListAsync();
    }

    //public async Task<Patient?> GetPatientWithVisitsAsync(int patientId)
    //{
    //    return await _context.Patients
    //        .Include(p => p.PatientVisits)
    //        .ThenInclude(v => v.Doctor)
    //        .FirstOrDefaultAsync(p => p.PatientId == patientId);
    //}

    public async Task<IEnumerable<Patient>> SearchPatientsAsync(string searchTerm)
    {
        return await _context.Patients
            .Where(p => p.FirstName.Contains(searchTerm) ||
                       p.LastName.Contains(searchTerm) ||
                       p.PhoneNumber!.Contains(searchTerm) ||
                       p.Email!.Contains(searchTerm))
            .ToListAsync();
    }
    //public async Task<IEnumerable<Patient>> SearchPatientsAsync(string term)
    //{
    //    var searchTerm = term.ToLower();
    //    return await _context.Patients
    //        .Where(p => p.FirstName.ToLower().Contains(searchTerm) ||
    //                   p.LastName.ToLower().Contains(searchTerm) ||
    //                   (p.PhoneNumber ?? "").ToLower().Contains(searchTerm) ||
    //                   (p.Email ?? "").ToLower().Contains(searchTerm))
    //        .ToListAsync();
    //}
}
