public interface IAuthRepository
{
    Task<User> LogIn(User user);
    Task LogOut();
}