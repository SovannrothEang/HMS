namespace Hospital_management_system.Application.DTOs;

public class DepartmentDto : BaseDtoEntity
{
    public string DepartmentId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
