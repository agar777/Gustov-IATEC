public interface IUser
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
    Task Save(User user);
    Task Update(int id, User user);
    Task Delete(int id);
}