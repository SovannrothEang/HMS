using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

[Table("tbl_staffs")]
public class Staff : Person
{
    #region - Fields
    private string _staffId = null!;
    private string _position = null!;
    private DateTime _hiredDate;
    private decimal _salary;
    private string _departmentId = null!;
    #endregion

    #region + Property
    [Key]
    [Column("staff_id", TypeName = "varchar(150)")]
    public string StaffId
    {
        get => _staffId;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid ID", nameof(value));

            _staffId = value;
        }
    }
    [Column("position", TypeName = "varchar(150)")]
    public string Position
    {
        get => _position;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid ID", nameof(value));

            _position = value;
        }
    }
    [Column("hired_date", TypeName = "datetime2")]
    public DateTime HiredDate
    {
        get => _hiredDate;
        set => _hiredDate = value;
    }
    [Column("salary", TypeName = "decimal(18,2)")]
    public decimal Salary
    {
        get => _salary;
        set
        {
            if (value < 0 || value > decimal.MaxValue)
                throw new ArgumentException("Invalid ID", nameof(value));

            _salary = value;
        }
    }

    [Column("department_id", TypeName = "varchar(150)")]
    public string DepartmentId
    {
        get => _departmentId;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid Department ID", nameof(value));

            _departmentId = value;
        }
    }
    #endregion

    #region Navigation Prop
    public virtual Department Department { get; set; } = null!;
    public virtual Doctor? Doctor { get; set; }
    public virtual User? User { get; set; }
    #endregion
}
