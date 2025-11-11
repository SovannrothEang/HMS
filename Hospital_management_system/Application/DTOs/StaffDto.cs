using Hospital_management_system.Domain.ValueObjects;

namespace Hospital_management_system.Application.DTOs;

public class StaffDto
{
    public string StaffId { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public PersonGender Gender { get; set; }
    public DateTime DOB { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string Position { get; set; } = string.Empty;
    public DateTime HiredDate { get; set; }
    public decimal Salary { get; set; }
    public string DepartmentId { get; set; } = string.Empty;
    public bool StopWorking { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public DepartmentDto? Department { get; set; }
}
