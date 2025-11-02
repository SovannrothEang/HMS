using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_mangement_system.Domain.Entities;

[Table("tbl_patients")]
public class Patient : Person
{
    [Key]
    [Column("patient_id", TypeName = "varchar(150)")]
    public string PatientId { get; set; } = string.Empty;
    [Column("emergency_contact_name", TypeName = "varchar(150)")]
    public string? EmergencyContactName { get; set; }
    [Phone]
    [Column("emergency_contact_phone", TypeName = "varchar(20")]
    public string? EmergencyContactPhone { get; set; }
    //[StringLength(100)]
    //public string? InsuranceProvider { get; set; }
    //[StringLength(50)]
    //public string? InsurancePolicyNumber { get; set; }
    [Column("blood_type", TypeName = "varchar(5)")]
    public string? BloodType { get; set; }
}
