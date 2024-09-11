public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAll();
    Task<UserDto> GetById(int id);
    Task Save(UserDto userDto);
    Task Update(int id, UserDto userDto);
    Task Delete(int id);
}