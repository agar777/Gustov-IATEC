
public class RequestService : IRequestService
{
    private readonly IRequestRepository requestRepository;
    public RequestService(IRequestRepository requestRepository)
    {
        this.requestRepository = requestRepository;
    }

    public  RequestDto GetById(int id)
    {
        var request = requestRepository.GetById(id);
        if (request == null)
        {
            return null;
        }

        return new RequestDto{
            Id = request.Id,
            EmployeeId = request.EmployeeId,
            RequestDate = request.RequestDate,
            Status = request.Status,
            Employee = request.Employee != null ? new EmployeeDto{
                Id = request.Employee.Id,
                Name = request.Employee.Name,
                LastName = request.Employee.LastName,
                Address = request.Employee.Address,
                HireDate = request.Employee.HireDate
            }: null
        };
    }

    public async Task SaveRequest(RequestDto requestDto)
    {
        var request = new Request{
            EmployeeId = requestDto.EmployeeId,
            RequestDate = requestDto.RequestDate,
            Status = requestDto.Status
        };

        await requestRepository.SaveRequest(request);

    }
}