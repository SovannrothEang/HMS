namespace Hospital_mangement_system.Application.DTO;

public class DoctorDto
{
    public string DoctorId { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Fullname { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public DateTime HiredDate { get; set; }
    public decimal Salary { get; set; }
}
