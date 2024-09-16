
using Microsoft.EntityFrameworkCore;

public class UserRepository: IUserRepository
{
    private readonly GustovContext context;
    public UserRepository(GustovContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await context.Users
        .Include(u => u.Role)
        .ToListAsync();
    }

    public async Task<User> GetById(int id)
    {
         return await context.Users.Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> GetByEmail(string email)
    {
        return await context.Users.SingleOrDefaultAsync(u => u.Email== email);
    }
    public async Task Save(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user!=null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}