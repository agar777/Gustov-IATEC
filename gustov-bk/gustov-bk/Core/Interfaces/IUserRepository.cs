public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
    Task Save(User user);
    Task Update(User user);
    Task Delete(int id);
}