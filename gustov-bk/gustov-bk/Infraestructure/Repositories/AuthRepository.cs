
using Microsoft.EntityFrameworkCore;

public class AuthRepository: IAuthRepository
{
    private readonly GustovContext context;

    public AuthRepository(GustovContext context)
    {
        this.context = context;
    }

    public async Task<User> LogIn(User user)
    {
        return await context.Users.SingleOrDefaultAsync(u=> u.Email == user.Email);
    }

    public Task LogOut()
    {
        throw new NotImplementedException();
    }
}