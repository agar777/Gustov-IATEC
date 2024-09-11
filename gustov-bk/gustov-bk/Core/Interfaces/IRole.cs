public interface IRole
{
    Task<IEnumerable<Role>> GetAll();
    Task<Role> GetById(int id);
    Task Save(Role role);
    Task Update(int id, Role role);
    Task Delete(int id);
}