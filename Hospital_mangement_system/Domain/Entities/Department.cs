using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_mangement_system.Domain.Entities;

[Table("tbl_departments")]
public class Department : BaseClass
{
    [Key]
    [Column("department_id", TypeName = "varchar(150)")]
    public string DepartmentId { get; set; } = string.Empty;
    [Column("name", TypeName = "varchar(150)")]
    public string Name { get; set; } = string.Empty;
    [Column("description", TypeName = "varchar(500)")]
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<Staff> Staffs { get; set; } = [];
}
