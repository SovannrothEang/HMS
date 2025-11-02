using Hospital_mangement_system.Application.DTO;
using Hospital_mangement_system.Application.Interfaces;

namespace Hospital_mangement_system.Infrastructure.Services;

public class DoctorService : IDoctorService
{
    public Task<IEnumerable<DoctorDto>> GetAllAsyc()
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDto?> GetByCodeAsyc(string code)
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDto?> GetByIdAsyc(string id)
    {
        throw new NotImplementedException();
    }
    public Task<bool> CreateAsync(DoctorCreateDto dto)
    {
        throw new NotImplementedException();
    }
    public Task<bool> UpdateAsync(string id, DoctorUpdateDto dto)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}
