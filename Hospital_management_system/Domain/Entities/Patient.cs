using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

[Table("tbl_patients")]
public class Patient : Person
{
    [Key]
    [Column("patient_id", TypeName = "varchar(150)")]
    public string PatientId { get; set; } = string.Empty;
    [Column("emergency_contact_name", TypeName = "varchar(150)")]
    public string? EmergencyContactName { get; set; }
    [Phone]
    [Column("emergency_contact_phone", TypeName = "varchar(20)")]
    public string? EmergencyContactPhone { get; set; }
    // [Column("medical_history", TypeName = "varchar(max)")]
    // public string? MedicalHistory { get; set; }
    //[StringLength(100)]
    //public string? InsuranceProvider { get; set; }
    //[StringLength(50)]
    //public string? InsurancePolicyNumber { get; set; }
    [Column("blood_type", TypeName = "varchar(5)")]
    public string? BloodType { get; set; }
    [Column("allergies", TypeName = "varchar(max)")]
    public string? Allergies { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = [];
    //public virtual ICollection<PatientVisit> PatientVisits { get; set; } = new List<PatientVisit>();
    //public virtual ICollection<PatientService> PatientServices { get; set; } = new List<PatientService>();
    //public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
