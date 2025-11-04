using Hospital_management_system.Domain.ValueObjects;

namespace Hospital_management_system.Application.DTO.Staff;

public class StaffCreateDto
{
    public string Code { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DOB { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string Position { get; set; } = string.Empty;
    public DateTime HiredDate { get; set; }
    public decimal Salary { get; set; }
    public string DepartmentId { get; set; } = string.Empty;

}
