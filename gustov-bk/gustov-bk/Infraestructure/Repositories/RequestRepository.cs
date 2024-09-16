

using Microsoft.EntityFrameworkCore;

public class RequestRepository : IRequestRepository
{
    private readonly GustovContext context;
    public RequestRepository(GustovContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Request>> GetAll()
    {
       return await context.Requests
        .Include(u => u.Employee)
        .ToListAsync();
    }

    public Request GetById(int id)
    {
       return context.Requests
        .Include(u => u.Employee)
        .SingleOrDefault(r => r.Id == id);
    }

    public async Task SaveRequest(Request request)
    {
        await context.Requests.AddAsync(request);
        await context.SaveChangesAsync();
    }

    public async Task Update(Request request)
    {
        context.Requests.Update(request);
        await context.SaveChangesAsync();
    }

    public async Task<Request> GetRequestsByEmployee(int employeeId, int year)
    {
          return await context.Requests
            .Where(r => r.EmployeeId == employeeId && r.RequestDate.Year == year)
            .FirstOrDefaultAsync();
    }
}