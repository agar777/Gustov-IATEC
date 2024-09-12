public class Request
{
    public int Id {get;set;}
    public int EmployeeId {get;set;}
    public DateOnly RequestDate {get;set;}
    public string? Status {get;set;}
    public Employee? Employee {get;set;}
    public ICollection<Vacation>? Vacations {get;set;}

}