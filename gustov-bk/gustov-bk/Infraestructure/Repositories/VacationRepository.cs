
public class VacationRepository : IVacationRepository
{
    private readonly GustovContext context;
    public VacationRepository(GustovContext context)
    {
        this.context = context;
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