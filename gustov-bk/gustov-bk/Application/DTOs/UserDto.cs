public class UserDto:PersonDto
{
    public int RoleId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public RoleDto? Role { get; set; } 
}