public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAll();
    Task<RoleDto> GetById(int id);
    Task Save(RoleDto roleDto);
    Task Update(int id, RoleDto roleDto);
    Task Delete(int id);
}