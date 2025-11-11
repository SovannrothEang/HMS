using Hospital_management_system.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Hospital_management_system.Domain.Entities;

public abstract class Person : BaseEntity
{
    #region - Fields
    private string _firstname = null!;
    private string _lastname = null!;
    private DateTime _dob;
    private PersonGender _gender;
    private string? _phonenumber;
    private string? _address;
    private string? _email;
    #endregion

    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    #region + Props
    [Required]
    [Column("firstname", TypeName = "varchar(70)")]
    public string FirstName 
    {
        get => _firstname;
        set
        {
            _firstname = !string.IsNullOrEmpty(value.Trim())
                ? value.Trim()
                : throw new ArgumentException("Firstname cannot be empty or null!", nameof(value));
        }
    }
    [Column("lastname", TypeName = "varchar(70)")]
    public string LastName
    {
        get => _lastname;
        set
        {
            _lastname= !string.IsNullOrEmpty(value.Trim())
                ? value.Trim()
                : throw new ArgumentException("Lastname cannot be empty or null!", nameof(value));
        }
    }
    [Column("dob", TypeName = "varchar(150)")]
    public DateTime DOB 
    {
        get => _dob;
        set => _dob = value;
    }
    [Required]
    [Column("gender", TypeName = "integer")]
    public PersonGender Gender
    {
        get => _gender;
        set
        {
            if (!Enum.IsDefined(typeof(PersonGender), value))
                throw new ArgumentException("Invalid gender value.", nameof(value));

            _gender = value;
        }
    }
    [Phone]
    [Column("phonenumber", TypeName = "varchar(20)")]
    public string? PhoneNumber
    {
        get => _phonenumber;
        set => _phonenumber = value;
    }
    [Column("address", TypeName = "varchar(50)")]
    public string? Address
    {
        get => _address;
        set => _address = value;
    }
    [EmailAddress]
    [Column("email", TypeName = "varchar(150)")]
    public string? Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                _email = value;
            }
            else if (EmailRegex.IsMatch(value) && value != null)
            {
                _email = value;
            }
            else
            {
                throw new ArgumentException("Invalid email format.", nameof(value));
            }

        }
    }
    #endregion
}
