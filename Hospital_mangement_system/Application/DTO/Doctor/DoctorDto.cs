using Hospital_mangement_system.Domain.ValueObjects;

namespace Hospital_mangement_system.Application.DTO.Doctor;

public class DoctorDto
{
    public string DoctorId { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DOB { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string Specialization { get; set; } = string.Empty;
    public int YearsOfExperiense { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime HiredDate { get; set; }
    public decimal Salary { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
