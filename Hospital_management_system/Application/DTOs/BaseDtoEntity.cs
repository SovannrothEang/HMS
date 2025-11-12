namespace Hospital_management_system.Application.DTOs;

public class BaseDtoEntity
{
    public string Code { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
