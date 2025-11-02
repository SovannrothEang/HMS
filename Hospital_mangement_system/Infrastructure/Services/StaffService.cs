using Hospital_mangement_system.Application.DTO.Staff;
using Hospital_mangement_system.Application.Interfaces;
using Hospital_mangement_system.Domain.Repositories;
using Hospital_mangement_system.Application.Mapper;

namespace Hospital_mangement_system.Infrastructure.Services;

public class StaffService(IStaffRepository repo) : IStaffService
{
    private readonly IStaffRepository _repo = repo;
    public async Task<IEnumerable<StaffDto>> GetAllAsyc()
    {
        var queryable = await _repo.GetAllAsyc();
        return queryable.Select(s => s.ToDto());
    }
    public async Task<StaffDto?> GetByCodeAsyc(string code)
    {
        //return await _repo.GetByCodeAsync(code) is Staff staff ? staff.ToDto() : null;
        var found = await _repo.GetByCodeAsync(code);
        return found?.ToDto();
    }
    public async Task<StaffDto?> GetByIdAsyc(string id)
    {
        var found = await _repo.GetByIdAsyc(id);
        return found?.ToDto();
    }
    public async Task<StaffDto> CreateAsync(StaffCreateDto dto)
    {
        var entity = dto.ToEntity();
        var created = await _repo.CreateAsync(entity);
        return created.ToDto();
    }

    public Task<bool> DeleteAsync(string id)
    {
        return _repo.DeleteAsync(id);
    }    
}
