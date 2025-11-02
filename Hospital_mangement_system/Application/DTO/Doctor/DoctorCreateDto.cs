using Hospital_mangement_system.Domain.ValueObjects;

namespace Hospital_mangement_system.Application.DTO.Doctor;

public class DoctorCreateDto
{
    public string Code { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string DOB { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string Specialization { get; set; } = string.Empty;
    public string YearsOfExperiense { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime HiredDate { get; set; }
    public decimal Salary { get; set; }
}
