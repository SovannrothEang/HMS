using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

[Table("tbl_positions")]
public class Position : BaseEntity
{
    #region - Field
    private string _positionId = null!;
    private string _name = null!;
    private string? _description;
    private string _departmentId = null!;
    #endregion

    #region + Property
    [Key]
    [Column("position_id", TypeName = "varchar(150)")]
    public string PositionId
    {
        get => _positionId;
        set => _positionId = value;
    }

    [Required]
    [Column("name", TypeName = "varchar(255)")]
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    [Column("description", TypeName = "varchar(500)")]
    public string? Description
    {
        get => _description;
        set => _description = value;
    }

    [Required]
    [Column("department_id", TypeName = "varchar(150)")]
    public string DepartmentId
    {
        get => _departmentId;
        set => _departmentId = value;
    }
    #endregion

    #region + Relationship
    public Department? Department { get; set; }
    #endregion
}
