public class VacationValidators: IVacationValidator
{

    public (int daysPerYearWorked,DateOnly endDate) ValidateVacationDay(IRequestService requestService, VacationDto vacationDto)
    {
        var request = requestService.GetById(vacationDto.RequestId);
        int yearsWorked = CalculateYearsWorked(requestService,vacationDto);
        int daysPerYearWorked = CalculateDaysVacations(yearsWorked);

        DateTime requestDay = request.RequestDate.ToDateTime(TimeOnly.MinValue);
        DateOnly endDate = DateOnly.FromDateTime(requestDay.AddDays(daysPerYearWorked));
        
        return (daysPerYearWorked,endDate);
    }

    public bool ValidateVacationRequest(IRequestService requestService, VacationDto vacationDto){

       int yearsWorked = CalculateYearsWorked(requestService,vacationDto);

       return yearsWorked >= 1;
        
    }

    private int CalculateYearsWorked(IRequestService requestService, VacationDto vacationDto){

        var request = requestService.GetById(vacationDto.RequestId);
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
            >= 6 and <= 20 => 20,
            >= 21 => 30,
            _ => 0 
        };
    }

}