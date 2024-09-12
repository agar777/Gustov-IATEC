public class Employee: Person
{
    public DateOnly HireDate  {get;set;}
    public ICollection<Request>? Requests {get;set;}
    
}