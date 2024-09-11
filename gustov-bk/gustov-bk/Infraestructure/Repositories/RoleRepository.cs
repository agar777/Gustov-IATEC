
using Microsoft.EntityFrameworkCore;

public class RoleRepository : IRoleRepository
{
    private readonly GustovContext _context;
    public RoleRepository(GustovContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role> GetById(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task Save(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role != null)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }

}