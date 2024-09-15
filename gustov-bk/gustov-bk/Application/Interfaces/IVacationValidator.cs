public interface IVacationValidator
{
    bool ValidateVacationRequest(IRequestService requestService, VacationDto vacationDto);
    (int daysPerYearWorked,DateOnly endDate) ValidateVacationDay(IRequestService requestService, VacationDto vacationDto);
}