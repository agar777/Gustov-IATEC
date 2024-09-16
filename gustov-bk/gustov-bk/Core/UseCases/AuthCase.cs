public class AuthCase
{
    private readonly IUserRepository userRepository;
    private readonly IJwtService jwtService;

    public AuthCase(IUserRepository userRepository, IJwtService jwtService)
    {
        this.userRepository = userRepository;
        this.jwtService = jwtService;
    }

    public async Task<string> Execute(string email, string password)
    {
        var user = await userRepository.GetByEmail(email);

        if (user == null || !VerifyPassword(password, user.Password))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        return jwtService.GenerateToken(user);
    }

    private bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}