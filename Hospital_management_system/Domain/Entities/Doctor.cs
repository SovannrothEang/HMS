using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

[Table("tbl_doctors")]
public class Doctor : BaseEntity
{
    [Key]
    [Column("doctor_id", TypeName = "varchar(150)")]
    public string DoctorId { get; init; } = null!;
    [Column("specialization", TypeName = "varchar(150)")]
    public string Specialization { get; set; } = string.Empty;
    [Column("license_number", TypeName = "varchar(150)")]
    public string LicenseNumber { get; set; } = string.Empty;
    [Column("years_of_experience ", TypeName = "integer")]
    public int YearsOfExperiense { get; set; }
    [Column("stopped_work", TypeName = "bit")]
    public bool StoppedWork { get; set; } = false;

    public virtual Staff Staff { get; set; } = null!;
    public virtual ICollection<Patient> Patients { get; set; } = [];
}
