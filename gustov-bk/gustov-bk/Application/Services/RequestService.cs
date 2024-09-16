
public class RequestService : IRequestService
{
    private readonly IRequestRepository requestRepository;
    private readonly IRequestValidator requestValidator;
    public RequestService(IRequestRepository requestRepository, IRequestValidator requestValidator)
    {
        this.requestRepository = requestRepository;
        this.requestValidator = requestValidator;
    }

     public async Task<IEnumerable<RequestDto>> GetAll()
    {
        var requests = await requestRepository.GetAll();
        return requests.Select(request=>new RequestDto{
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
        });
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
        await requestValidator.ValidateRequestByEmployee(requestRepository,requestDto);
        
        var request = new Request{
            EmployeeId = requestDto.EmployeeId,
            RequestDate = requestDto.RequestDate,
            Status = requestDto.Status
        };

        await requestRepository.SaveRequest(request);

    }
    public async Task Update(int id)
    {
        var request = requestRepository.GetById(id);
        string status = "APPROVED";

        if (request != null)
        {
            request.Id = id;
            request.Status = status;
            await requestRepository.Update(request);
        }
    }

}