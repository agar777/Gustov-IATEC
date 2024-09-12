
public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

     public async Task<IEnumerable<UserDto>> GetAll()
    {
        var users = await _userRepository.GetAll();
        return users.Select(e=>new UserDto{
            Id = e.Id,
            RoleId = e.RoleId,
            CompanyId = e.CompanyId,
            Name = e.Name,
            LastName = e.LastName,
            StartDate  = e.StartDate,
            Email = e.Email,
            Role = e.Role,
            Company = e.Company
        });
    }

    public async Task<UserDto> GetById(int id)
    {
        var user = await _userRepository.GetById(id);
        if (user==null)
        {
            return null;
        }

        return new UserDto{
            Id = user.Id,
            RoleId = user.RoleId,
            CompanyId = user.CompanyId,
            Name = user.Name,
            LastName = user.LastName,
            StartDate  = user.StartDate,
            Email = user.Email,
            Role = user.Role,
            Company = user.Company
        };
    }

    public async Task Save(UserDto userDto)
    {
        var user = new User{
            RoleId = userDto.RoleId,
            CompanyId = userDto.CompanyId,
            Name = userDto.Name,
            LastName = userDto.LastName,
            StartDate  = userDto.StartDate,
            Email = userDto.Email,
            Password = userDto.Password
        };
        await _userRepository.Save(user);
    }

    public async Task Update(UserDto userDto)
    {
        var user = await _userRepository.GetById(userDto.Id);
        if (user!=null)
        {
            user.RoleId = userDto.RoleId;
            user.CompanyId = userDto.CompanyId;
            user.Name = userDto.Name;
            user.LastName = userDto.LastName;
            user.StartDate  = userDto.StartDate;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            await _userRepository.Update(user);
        }
    }

    public async Task Delete(int id)
    {
        await _userRepository.Delete(id);
    }
}