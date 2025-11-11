using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

[Table("tbl_patients")]
public class Patient : Person
{
    #region - Fields
    private string _patientId = null!;
    private string _sickness = null!;
    private string _doctorId = null!;
    #endregion

    #region + Props
    [Key]
    [Column("patient_id", TypeName = "varchar(150)")]
    public string PatientId
    {
        get => _patientId;
        set
        {
            if (string.IsNullOrEmpty(value.Trim()))
                throw new ArgumentNullException(nameof(value));

            _patientId = value.Trim();
        }
    }
    [Column("sickness", TypeName = "varchar(150)")]
    public string Sickness
    {
        get => _sickness;
        set
        {
            if (string.IsNullOrEmpty(value.Trim()))
                throw new ArgumentNullException(nameof(value));

            _sickness = value.Trim();
        }
    }
    [Column("doctor_id", TypeName = "varchar(150)")]
    public string DoctorId
    {
        get => _doctorId;
        set
        {
            if (string.IsNullOrEmpty(value.Trim()))
                throw new ArgumentNullException(nameof(value));

            _doctorId = value.Trim();
        }
    }
    //[Column("emergency_contact_name", TypeName = "varchar(150)")]
    //public string? EmergencyContactName { get; set; }
    //[Phone]
    //[Column("emergency_contact_phone", TypeName = "varchar(20)")]
    //public string? EmergencyContactPhone { get; set; }
    // [Column("medical_history", TypeName = "varchar(max)")]
    // public string? MedicalHistory { get; set; }
    //[StringLength(100)]
    //public string? InsuranceProvider { get; set; }
    //[StringLength(50)]
    //public string? InsurancePolicyNumber { get; set; }
    //[Column("blood_type", TypeName = "varchar(5)")]
    //public string? BloodType { get; set; }
    //[Column("allergies", TypeName = "varchar(max)")]
    //public string? Allergies { get; set; }
    #endregion

    #region + Navigation Props
    public virtual Doctor Doctor { get; set; } = null!;
    //public virtual ICollection<PatientVisit> PatientVisits { get; set; } = new List<PatientVisit>();
    //public virtual ICollection<PatientService> PatientServices { get; set; } = new List<PatientService>();
    //public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
    #endregion
}
