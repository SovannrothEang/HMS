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
            Code = entity.Code,
            LicenseNumber = entity.LicenseNumber,
            YearsOfExperience = entity.YearsOfExperience,
            Specialization = entity.Specialization,
            StoppedWork = entity.StoppedWork,
            StaffId = entity.StaffId,
            Staff = entity.Staff?.ToDto(),
            CreatedAt = entity.Staff == null ? entity.CreatedAt : entity.Staff.CreatedAt,
            UpdatedAt = entity.Staff?.UpdatedAt,
        };
    }
}
