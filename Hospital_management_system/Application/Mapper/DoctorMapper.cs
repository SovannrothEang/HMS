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
            StaffId = entity.StaffId,
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
            StaffId = dto.StaffId,
            Staff = staff,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };
    }

    public static void CopyTo(this DoctorDto dto, DoctorDto doctor)
    {
        dto.DoctorId = doctor.DoctorId;
        dto.LicenseNumber = doctor.LicenseNumber;
        dto.YearsOfExperiense = doctor.YearsOfExperiense;
        dto.Specialization = doctor.Specialization;
        dto.StoppedWork = doctor.StoppedWork;
        dto.StaffId = doctor.StaffId;
        dto.Staff = doctor.Staff;
        dto.CreatedAt = doctor.Staff.CreatedAt;
        dto.UpdatedAt = doctor.Staff?.UpdatedAt;
    }
}
