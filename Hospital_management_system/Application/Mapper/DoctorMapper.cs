using Hospital_management_system.Application.DTO.Doctor;
using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Application.Mapper;

public static class DoctorMapper
{
    public static Doctor ToEntity(this DoctorDto dto)
    {
        return new Doctor()
        {
            DoctorId = Guid.NewGuid().ToString(),
            LicenseNumber = dto.LicenseNumber,
            YearsOfExperiense = dto.YearsOfExperiense,
            Specialization = dto.Specialization,
            HiredDate = dto.HiredDate,
            Salary = dto.Salary,
        };
    }

    public static DoctorDto ToDto(this Doctor entity)
    {
        return new DoctorDto()
        {
            DoctorId = entity.DoctorId,
            LicenseNumber = entity.LicenseNumber,
            YearsOfExperiense = entity.YearsOfExperiense,
            Specialization = entity.Specialization,
            HiredDate = entity.HiredDate,
            Salary = entity.Salary,
        };
    }
}
