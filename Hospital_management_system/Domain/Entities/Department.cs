using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

[Table("tbl_departments")]
public class Department : BaseEntity
{
    #region - Fields
    private string _departmentId = null!;
    private string _name = null!;
    private string? _description;
    #endregion

    #region + Props
    [Key]
    [Column("department_id", TypeName = "varchar(150)")]
    public string DepartmentId
    {
        get => _departmentId;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid ID", nameof(value));

            _departmentId = value;
        }
    }
    [Column("name", TypeName = "varchar(150)")]
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid name for department", nameof(value));

            _name = value;
        }
    }
    [Column("description", TypeName = "varchar(500)")]
    public string? Description
    {
        get => _description;
        set => _description = value;
    }
    #endregion

    #region + Navigation Prop
    public virtual ICollection<Staff> Staffs { get; set; } = [];
    #endregion
}
