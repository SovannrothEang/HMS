namespace Hospital_management_system.Application.DTOs;

public class UserDto : BaseDtoEntity
{
    public string UserId { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string StaffId { get; set; } = null!;

    public StaffDto Staff { get; set; } = null!;
}
