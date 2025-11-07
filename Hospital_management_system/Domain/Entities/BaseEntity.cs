using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;
public abstract class BaseEntity
{
    [Required]
    [Column("code", TypeName = "varchar(150)")]
    public string Code { get; set; } = string.Empty;
    [Column("is_active", TypeName = "bit")]
    public bool IsActive { get; set; } = true;
    [Column("is_deleted", TypeName = "bit")]
    public bool IsDeleted { get; set; } = false;
    [Column("created_at", TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column("updated_at", TypeName = "datetime2")]
    public DateTime? UpdatedAt { get; set; } = null;
}