using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Application.Mapper;

public static class PatientMapper
{
    public static Patient ToEntity(this PatientDto dto)
    {
        return new Patient()
        {
            PatientId = Guid.NewGuid().ToString(),
            Code = dto.Code,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Gender = dto.Gender,
            DOB = dto.DOB,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            Email = dto.Email,
            Sickness = dto.Sickness,
            DoctorId = dto.DoctorId
        };
    }

    public static PatientDto ToDto(this Patient entity)
    {
        return new PatientDto()
        {
            PatientId = entity.PatientId,
            Code = entity.Code,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Gender = entity.Gender,
            DOB = entity.DOB,
            PhoneNumber = entity.PhoneNumber,
            Address = entity.Address,
            Email = entity.Email,
            Sickness = entity.Sickness,
            DoctorId = entity.DoctorId,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
}
