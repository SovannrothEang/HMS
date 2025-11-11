using Hospital_management_system.Domain.ValueObjects;

namespace Hospital_management_system.Application.DTOs;

public class PatientDto
{
    public string PatientId { get; set; } = null!;
    public string Code { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public PersonGender Gender { get; set; }
    public DateTime DOB { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string Sickness { get; set; } = string.Empty;
    public string DoctorId { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public DoctorDto? Doctor { get; set; } = null;
}
