using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;
public abstract class BaseEntity
{
    #region - Field
    private string _code = null!;
    private bool _isActive = true;
    private bool _isDeleted = false;
    private DateTime _createdAt;
    private DateTime? _updatedAt;
    #endregion

    #region + Property
    [Required]
    [Column("code", TypeName = "varchar(150)")]
    public string Code {
        get => _code;
        set
        {
            _code = value.Trim()
                ?? throw new ArgumentException("Code can't be null or empty", nameof(value));
        }
    }
    [Column("is_active", TypeName = "bit")]
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
        }
    }
    [Column("is_deleted", TypeName = "bit")]
    public bool IsDeleted
    {
        get => _isDeleted;
        set => _isDeleted = value;
    }
    [Column("created_at", TypeName = "datetime2")]
    public DateTime CreatedAt
    {
        get => _createdAt;
        init => _createdAt = DateTime.Now;
    }
    [Column("updated_at", TypeName = "datetime2")]
    public DateTime? UpdatedAt
    {
        get => _updatedAt;
        set => _updatedAt = value;
    }
    #endregion

    public virtual bool IsActiveAndNotDelete() => IsActive && !IsDeleted;
}