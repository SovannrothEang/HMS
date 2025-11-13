using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Application.Mapper;

public static class UserMapper
{
    public static UserDto ToDto(this User entity)
    {
        return new UserDto
        {
            UserId = entity.UserId,
            Code = entity.Code,
            Username = entity.Username,
            StaffId = entity.StaffId,
            Staff = entity.Staff.ToDto(),
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
        };
    }
}
