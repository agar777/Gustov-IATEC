public class VacationDto
{
    public int Id {get;set;}
    public int RequestId {get;set;}
    public DateOnly StartDate {get;set;} 
    public DateOnly EndDate {get;set;} 
    public int TotalDays{get;set;}
    public RequestDto? Request {get;set;}
}