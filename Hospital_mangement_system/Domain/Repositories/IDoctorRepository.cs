using Hospital_mangement_system.Domain.Entities;

namespace Hospital_mangement_system.Domain.Repositories;

public interface IDoctorRepository : IGenericRepository<Doctor>
{
    Task<Doctor?> GetByCodeAsync(string code);
}
