public class VacationDto
{
    public int Id {get;set;}
    public int RequestId {get;set;}
    public DateOnly StartDate {get;set;} 
    public DateOnly EndDate {get;set;} 
    public Request? Request {get;set;}
}