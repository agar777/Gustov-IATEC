public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAll();
    Task<Role> GetById(int id);
    Task Save(Role role);
    Task Update(Role role);
    Task Delete(int id);
}