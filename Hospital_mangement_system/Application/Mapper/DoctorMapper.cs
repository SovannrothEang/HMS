using Hospital_mangement_system.Application.DTO;
using Hospital_mangement_system.Domain.Entities;

namespace Hospital_mangement_system.Application.Mapper;

public static class DoctorMapper
{
    public static Doctor ToEntity(this DoctorDto dto)
    {
        return new Doctor()
        {
            DoctorId = Guid.NewGuid().ToString(),
            Code = dto.Code,
            Fullname = dto.Fullname,
            Specialization = dto.Specialization,
            HiredDate = dto.HiredDate,
            Salary = dto.Salary,
            CreatedAt = DateTime.UtcNow.AddHours(7),
        };
    }

    public static DoctorDto ToDto(this Doctor entity)
    {
        return new DoctorDto()
        {
            DoctorId = entity.DoctorId,
            Code = entity.Code,
            Fullname = entity.Fullname,
            Specialization = entity.Specialization,
            HiredDate = entity.HiredDate,
            Salary = entity.Salary,
        };
    }
}
