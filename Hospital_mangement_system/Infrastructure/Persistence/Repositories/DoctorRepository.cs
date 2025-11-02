using Hospital_mangement_system.Domain.Entities;
using Hospital_mangement_system.Domain.Repositories;

namespace Hospital_mangement_system.Infrastructure.Persistence.Repositories;

public class DoctorRepository(AppDbContext dbContext): IDoctorRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    public async Task<IEnumerable<Doctor>> GetAllAsyc()
    {
        var queryable = await _dbContext.Doctors.ToList()
    }
    public Task<Doctor?> GetByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }
    public Task<Doctor?> GetByIdAsyc(string id)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<Doctor>> FindAsync(Func<Doctor, bool> predicate)
    {
        throw new NotImplementedException();
    }
    public Task<bool> CreateAsync(Doctor doctor)
    {
        throw new NotImplementedException();
    }
    public Task<bool> UpdateAsync(string id, Doctor doctor)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}
