using Hospital_management_system.Application.DTO.Staff;
using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Application.Mapper;

public static class StaffMapper
{
    public static Staff ToEntity(this StaffCreateDto dto)
    {
        return new Staff()
        {
            StaffId = Guid.NewGuid().ToString(),
            Code = dto.Code,
            FirstName = dto.Firstname,
            LastName = dto.Lastname,
            Gender = dto.Gender,
            DOB = dto.DOB,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            Email = dto.Email,
            Position = dto.Position,
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
            Firstname = entity.FirstName,
            Lastname = entity.LastName,
            Gender = entity.Gender,
            DOB = entity.DOB,
            PhoneNumber = entity.PhoneNumber,
            Address = entity.Address,
            Email = entity.Email,
            Position = entity.Position,
            HiredDate = entity.HiredDate,
            Salary = entity.Salary,
            DepartmentId = entity.DepartmentId,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
}
