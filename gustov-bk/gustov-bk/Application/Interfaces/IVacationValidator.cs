public interface IVacationValidator
{
    bool ValidateVacationRequest(IRequestService requestService, int requestId);
    (int daysPerYearWorked,DateOnly endDate) ValidateVacationDay(IRequestService requestService, int requestId);
}