using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hospital_management_system.Infrastructure.Persistence.Repositories;

public class DoctorRepository (AppDbContext context) : IDoctorRepository
{
    private readonly AppDbContext _context = context;
    public async Task<IEnumerable<Doctor>> GetAllWithStaffAsync()
    {
        return await _context.Doctors
            .Include(d => d.Staff)
            .ThenInclude(s => s.Department)
            .ToListAsync();
    }
    public async Task<Doctor?> GetByIdWithStaffAsync(string id)
    {
        return await _context.Doctors
            .Include(d => d.Staff)
            .ThenInclude(s => s.Department)
            .FirstOrDefaultAsync(d => d.DoctorId == id);
    }
    public async Task<Doctor?> GetWithAppointmentsAsync(string id)
    {
        return await _context.Doctors
            .Include(d => d.Staff)
            .Include(d => d.Appointments)
            .ThenInclude(d => d.Patient)
            .FirstOrDefaultAsync(d => d.DoctorId == id);
    }
    public async Task<IEnumerable<Doctor>> SearchAsync(string searchTerm)
    {
        var founds = await _context.Doctors
            .Include(d => d.Staff)
            .ThenInclude(s => s.Department)
            .Where(d => d.Staff.FirstName.Contains(searchTerm) ||
                       d.Staff.LastName.Contains(searchTerm) ||
                       d.Specialization.Contains(searchTerm) ||
                       d.LicenseNumber.Contains(searchTerm))
            .ToListAsync();

        return founds.Count == 0 ? [] : founds;
    }
}