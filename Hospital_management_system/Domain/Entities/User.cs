using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

[Table("tbl_users")]
public class User : BaseEntity
{
    #region - Fields
    private string _userId = null!;
    private string _username = null!;
    private string _password = null!;
    private string _staff_id = null!;
    #endregion

    #region + Props
    [Column("user_id", TypeName = "varchar(150)")]
    public string UserId
    {
        get => _userId;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            _userId = value;
        }
    }
    [Column("username", TypeName = "varchar(150)")]
    public string Username
    {
        get => _username;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            _username = value;
        }
    }
    [Column("password", TypeName = "varchar(255)")]
    public string Password
    {
        get => _password;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            _password = value;
        }
    }
    [Column("staff_id", TypeName = "varchar(150)")]
    public string StaffId
    {
        get => _staff_id;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            _staff_id = value;
        }
    }
    #endregion

    public virtual Staff? Staff { get; set; } = null!;
}
