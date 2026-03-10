using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Application.Mapper;

public static class PositionMapper
{
    public static PositionDto ToDto(this Position position)
    {
        return new PositionDto()
        {
            PositionId = position.PositionId,
            Code = position.Code,
            Name = position.Name,
            Description = position.Description,
            DepartmentId = position.DepartmentId,
            Department = position.Department?.ToDto(),
            CreatedAt = position.CreatedAt,
            UpdatedAt = position.UpdatedAt
        };
    }
}
