
public class VacationRepository : IVacationRepository
{
    private readonly GustovContext context;
    private readonly RequestRepository requestRepository;
    public VacationRepository(GustovContext context, RequestRepository requestRepository)
    {
        this.context = context;
        this.requestRepository = requestRepository;
    }

    public async Task<Vacation> GetById(int id)
    {
        return await context.Vacations.FindAsync(id);
    }

    public async Task SaveVacation(Vacation vacation)
    {
        await context.Vacations.AddAsync(vacation);
        await context.SaveChangesAsync();
    }

}