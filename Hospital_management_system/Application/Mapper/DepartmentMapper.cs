using Hospital_management_system.Application.DTO;
using Hospital_management_system.Domain.Entities;

namespace Hospital_management_system.Application.Mapper;

public static class DepartmentMapper
{
    public static DepartmentDto ToDto(this Department department)
    {
        return new DepartmentDto()
        {
            DepartmentId = department.DepartmentId,
            Code = department.Code,
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt,
            UpdatedAt = department.UpdatedAt
        };
    }
}
