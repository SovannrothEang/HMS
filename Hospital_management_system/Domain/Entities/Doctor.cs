using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

[Table("tbl_doctors")]
public class Doctor : BaseEntity
{
    #region - Fields
    private string _doctorId = null!;
    private string _specialization = null!;
    private string _licensenumber = null!;
    private int _experience;
    private bool _stoppedWork;
    private string _staffId = null!;
    #endregion

    #region + Props
    [Key]
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
    [Column("specialization", TypeName = "varchar(150)")]
    public string Specialization
    {
        get => _specialization;
        set
        {
            if (string.IsNullOrEmpty(value.Trim()))
                throw new ArgumentNullException(nameof(value));

            _specialization = value.Trim();
        }
    }
    [Column("license_number", TypeName = "varchar(150)")]
    public string LicenseNumber
    {
        get => _licensenumber;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            
            _licensenumber = value;
        }
    }
    [Column("years_of_experience ", TypeName = "integer")]
    public int YearsOfExperience
    {
        get => _experience;
        set
        {
            if ( value < 0 || value > int.MaxValue)
                throw new ArgumentException("Invalid value for experience", nameof(value));

            _experience = value;
        }
    }
    [Column("stopped_work", TypeName = "bit")]
    public bool StoppedWork
    {
        get => _stoppedWork;
        set => _stoppedWork = value;
    }
    [Column("staff_id", TypeName = "varchar(150)")]
    public string StaffId
    {
        get => _staffId;
        set
        {
            if (string.IsNullOrEmpty(value.Trim()))
                throw new ArgumentNullException(nameof(value));

            _staffId = value.Trim();
        }
    }
    #endregion

    #region + Navigation Props
    public virtual Staff Staff { get; set; } = null!;
    public virtual ICollection<Patient> Patients { get; set; } = [];
    #endregion
}
