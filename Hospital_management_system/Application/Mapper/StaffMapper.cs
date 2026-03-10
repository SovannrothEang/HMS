using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.ValueObjects;

namespace Hospital_management_system.Application.Mapper;

public static class StaffMapper
{
    public static Staff ToEntity(this StaffDto dto)
    {
        return new Staff()
        {
            StaffId = Guid.NewGuid().ToString(),
            Code = dto.Code,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Gender = dto.Gender,
            DOB = dto.DOB,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            Email = dto.Email,
            PositionId = dto.PositionId,
            HiredDate = dto.HiredDate,
            Salary = dto.Salary,
            DepartmentId = dto.DepartmentId
        };
    }

    public static StaffDto ToDto(this Staff entity)
    {
        return new StaffDto()
        {
            StaffId = entity.StaffId,
            Code = entity.Code,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Gender = entity.Gender,
            DOB = entity.DOB,
            PhoneNumber = entity.PhoneNumber,
            Address = entity.Address,
            Email = entity.Email,
            PositionId = entity.PositionId,
            Position = entity.Position?.ToDto(),
            HiredDate = entity.HiredDate,
            Salary = entity.Salary,
            DepartmentId = entity.DepartmentId,
            Department = entity.Department?.ToDto(),
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
}
