using Hospital_mangement_system.Application.DTO.Doctor;
using Hospital_mangement_system.Application.DTO.Staff;

namespace Hospital_mangement_system.Application.Interfaces;

public interface IStaffService
{
    Task<IEnumerable<StaffDto>> GetAllAsyc();
    Task<StaffDto?> GetByIdAsyc(string id);
    Task<StaffDto?> GetByCodeAsyc(string code);
    Task<StaffDto> CreateAsync(StaffCreateDto dto);
    //Task<bool> UpdateAsync(string id, DoctorUpdateDto dto);
    Task<bool> DeleteAsync(string id);
}
