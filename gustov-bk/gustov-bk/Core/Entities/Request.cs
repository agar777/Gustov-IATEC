public class Request
{
    public int Id {get;set;}
    public int UserId {get;set;}
    public DateOnly RequestDate {get;set;}
    public string? Status {get;set;}
    public User? User {get;set;}
    public ICollection<Vacation>? Vacations {get;set;}

}