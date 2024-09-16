public interface IVacationValidator
{
    bool ValidateVacationRequest(IRequestService requestService, int requestId);
    (int daysPerYearWorked,DateOnly endDate, int yearsWorked) ValidateVacationDay(IRequestService requestService, int requestId);
}