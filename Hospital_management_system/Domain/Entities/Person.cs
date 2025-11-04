using Hospital_management_system.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_management_system.Domain.Entities;

public abstract class Person : BaseClass
{
    [Required]
    [Column("firstname", TypeName = "varchar(70)")]
    public string FirstName { get; set; } = string.Empty;
    [Column("lastname", TypeName = "varchar(70)")]
    public string LastName { get; set; } = string.Empty;
    [Column("dob", TypeName = "varchar(150)")]
    public DateTime DOB { get; set; }
    [Required]
    [Column("gender", TypeName = "varchar(50)")]
    public Gender Gender { get; set; }
    [Phone]
    [Column("phonenumber", TypeName = "varchar(20)")]
    public string? PhoneNumber { get; set; }
    [Column("address", TypeName = "varchar(50)")]
    public string? Address { get; set; }
    [EmailAddress]
    [Column("email", TypeName = "varchar(150)")]
    public string? Email { get; set; } = null;
}
