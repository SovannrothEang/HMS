namespace Hospital_management_system.Application.DTOs;

public class DoctorDto : BaseDtoEntity
{
    public string DoctorId { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public int YearsOfExperience { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public bool StoppedWork { get; set; }
    public string StaffId { get; set; } = string.Empty;

    public StaffDto Staff { get; set; } = null!;
}
