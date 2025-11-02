using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_mangement_system.Domain.Entities;

[Table("tbl_appointments")]
public class Appointment : BaseClass
{
    [Key]
    [Column("appointment_id", TypeName = "varchar(150)")]
    public string AppointmentId { get; set; } = string.Empty;

    [Column("patient_id", TypeName = "varchar(150)")]
    public string PatientId { get; set; } = string.Empty;
    [Column("doctor_id", TypeName = "varchar(150)")]
    public string DoctorId { get; set; }  = string.Empty;

    [Column("appointment_date", TypeName = "datetime2")]
    public DateTime AppointmentDate { get; set; }
    [Column("duration_minutes", TypeName = "integer")]
    public int DurationMinutes { get; set; } = 30;
    [Column("purpose", TypeName = "varchar(200)")]
    public string? Purpose { get; set; }
    [Column("status", TypeName = "varchar(20)")]
    public string Status { get; set; } = "Scheduled";
    [Column("notes", TypeName = "varchar(500)")]
    public string? Notes { get; set; }

    public virtual Patient Patient { get; set; } = null!;
    public virtual Staff Doctor { get; set; } = null!;
}
