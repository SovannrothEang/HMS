using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Domain.Repositories;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetAllWithDoctorAsync();
}
