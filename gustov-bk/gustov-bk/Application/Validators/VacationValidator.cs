public class VacationValidators: IVacationValidator
{

    public (int daysPerYearWorked,DateOnly endDate, int yearsWorked) ValidateVacationDay(IRequestService requestService, int requestId)
    {
        var request = requestService.GetById(requestId);
        int yearsWorked = CalculateYearsWorked(requestService,requestId);
        int daysPerYearWorked = CalculateDaysVacations(yearsWorked);

        DateTime requestDay = request.RequestDate.ToDateTime(TimeOnly.MinValue);
        DateOnly endDate = DateOnly.FromDateTime(requestDay.AddDays(daysPerYearWorked));
        return (daysPerYearWorked,endDate, yearsWorked);
    }

    public bool ValidateVacationRequest(IRequestService requestService, int requestId){

       int yearsWorked = CalculateYearsWorked(requestService,requestId);
       if(yearsWorked<1){
            throw new InvalidOperationException("The employee has not yet completed one year of service.");
        }
       return yearsWorked >= 1;
        
    }

    private int CalculateYearsWorked(IRequestService requestService, int requestId){

        var request = requestService.GetById(requestId);
        var employee = request.Employee;

        DateTime hireDate = employee.HireDate.ToDateTime(TimeOnly.MinValue);
        DateTime requestDate = request.RequestDate.ToDateTime(TimeOnly.MinValue);

        TimeSpan timeWorked = requestDate - hireDate;
        int yearsWorked = (int)(timeWorked.Days / 365);
        return yearsWorked;
    }

    private int CalculateDaysVacations(int yearsWorked){
        return yearsWorked switch
        {
            >= 1 and <= 5 => 15,
            >= 6 and <= 10 => 20,
            >= 11 => 30,
            _ => 0 
        };
    }

}