namespace Hospital_management_system.Application.DTOs;

public class PositionDto : BaseDtoEntity
{
    public string PositionId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string DepartmentId { get; set; } = null!;
    public DepartmentDto? Department { get; set; }
}
