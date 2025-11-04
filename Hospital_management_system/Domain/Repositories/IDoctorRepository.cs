using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAllWithStaffAsync();
    Task<Doctor?> GetByIdWithStaffAsync(string id);
    Task<Doctor?> GetWithAppointmentsAsync(string id);
    Task<IEnumerable<Doctor>> SearchAsync(string searchTerm);
}
