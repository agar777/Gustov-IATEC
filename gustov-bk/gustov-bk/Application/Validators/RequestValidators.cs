public class RequestValidator : IRequestValidator
{

    public async Task ValidateRequestByEmployee(IRequestRepository requestRepository, RequestDto requestDto)
    {
        var currentYear = DateTime.Now.Year;
        var existingRequest = await requestRepository.GetRequestsByEmployee(requestDto.EmployeeId, currentYear);

        if (existingRequest != null)
        {
            throw new InvalidOperationException("The employee has already made a vacation request this year.");
        }
    }
}
