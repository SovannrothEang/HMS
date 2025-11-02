using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_mangement_system.Domain.Entities;

[Table("tbl_doctors")]
public class Doctor : Person
{
    [Key]
    [Column("doctor_id", TypeName = "varchar(150)")]
    public string DoctorId { get; set; } = string.Empty;
    [Column("specialization", TypeName = "varchar(150)")]
    public string Specialization { get; set; } = string.Empty;
    [Column("license_number", TypeName = "varchar(150)")]
    public string LicenseNumber { get; set; } = string.Empty;
    [Column("years_of_experiense ", TypeName = "integer")]
    public int YearsOfExperiense { get; set; } 
    [Column("hired_date", TypeName = "datetime2")]
    public DateTime HiredDate { get; set; }
    [Column("salary", TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }
    [Column("stopped_work", TypeName = "bit")]
    public bool StoppedWork { get; set; } = false;

    public virtual Staff Staff { get; set; } = null!;
}
