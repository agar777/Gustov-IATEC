public class RequestDto
{
    public int Id {get;set;}
    public int EmployeeId {get;set;}
    public DateOnly RequestDate {get;set;}
    public string? Status {get;set;}
    public EmployeeDto? Employee {get;set;}

}