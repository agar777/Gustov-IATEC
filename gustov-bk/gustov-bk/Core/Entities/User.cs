public class User:Person
{
    public int RoleId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Role? Role { get; set; }
}