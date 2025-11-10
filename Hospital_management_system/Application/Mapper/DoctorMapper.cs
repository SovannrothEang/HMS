using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Application.Mapper;

public static class DoctorMapper
{
    public static DoctorDto ToDto(this Doctor entity)
    {
        return new DoctorDto()
        {
            DoctorId = entity.DoctorId,
            LicenseNumber = entity.LicenseNumber,
            YearsOfExperiense = entity.YearsOfExperiense,
            Specialization = entity.Specialization,
            StoppedWork = entity.StoppedWork,
            Staff = entity.Staff.ToDto(),
            CreatedAt = entity.Staff.CreatedAt,
            UpdatedAt = entity.Staff?.UpdatedAt,
        };
    }

    public static Doctor ToEntity(this DoctorDto dto, Staff staff)
    {
        return new Doctor()
        {
            DoctorId = dto.DoctorId,
            LicenseNumber = dto.LicenseNumber,
            YearsOfExperiense = dto.YearsOfExperiense,
            Specialization = dto.Specialization,
            StoppedWork = dto.StoppedWork,
            Staff = staff,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };
    }
}
