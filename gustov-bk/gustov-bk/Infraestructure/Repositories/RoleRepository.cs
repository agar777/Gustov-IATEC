
using Microsoft.EntityFrameworkCore;

public class RoleRepository : IRoleRepository
{
    private readonly GustovContext context;
    public RoleRepository(GustovContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        return await context.Roles.ToListAsync();
    }

    public async Task<Role> GetById(int id)
    {
        return await context.Roles.FindAsync(id);
    }

    public async Task Save(Role role)
    {
        await context.Roles.AddAsync(role);
        await context.SaveChangesAsync();
    }

    public async Task Update(Role role)
    {
        context.Roles.Update(role);
        await context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        var role = await context.Roles.FindAsync(id);
        if (role != null)
        {
            context.Roles.Remove(role);
            await context.SaveChangesAsync();
        }
    }

}