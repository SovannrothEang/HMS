using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

[Table("tbl_staffs")]
public class Staff : Person
{
    [Key]
    [Column("staff_id", TypeName = "varchar(150)")]
    public string StaffId { get; init; } = string.Empty;
    [Column("position", TypeName = "varchar(150)")]
    public string Position { get; set; } = string.Empty;
    [Column("hired_date", TypeName = "datetime2")]
    public DateTime HiredDate { get; set; }
    [Column("salary", TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }

    [Column("department_id", TypeName = "varchar(150)")]
    public string DepartmentId { get; set; } = string.Empty;
    public virtual Department Department { get; set; } = null!;

    public virtual Doctor? Doctor { get; set; }
}
