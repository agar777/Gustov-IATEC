public interface IAuthService
{
    Task<AuthDto> LogIn(AuthDto authDto);
    Task LogOut();
    
}