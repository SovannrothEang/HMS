using Hospital_mangement_system.Application.DTO;

namespace Hospital_mangement_system.Application.Interfaces;

public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetAllAsyc();
    Task<DoctorDto?> GetByIdAsyc(string id);
    Task<DoctorDto?> GetByCodeAsyc(string code);
    Task<bool> CreateAsync(DoctorCreateDto dto);
    Task<bool> UpdateAsync(string id, DoctorUpdateDto dto);
    Task<bool> DeleteAsync(string id);
}
