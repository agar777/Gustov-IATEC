public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAll();
    Task<RoleDto> GetById(int id);
    Task Save(RoleDto roleDto);
    Task Update(RoleDto roleDto);
    Task Delete(int id);
}