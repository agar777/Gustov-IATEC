
public class RequestRepository : IRequestRepository
{
    private readonly GustovContext context;
    public RequestRepository(GustovContext context)
    {
        this.context = context;
    }

    public Request GetById(int id)
    {
        return context.Requests.Find(id);
    }

    public async Task SaveRequest(Request request)
    {
        await context.Requests.AddAsync(request);
        await context.SaveChangesAsync();
        // var employee = await employeeRepository.GetById(EmployeeId);
        // TimeSpan totalTime = employee.HireDate - request.RequestDate;
    }
}