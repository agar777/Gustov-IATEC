
public class RolesService: IRoleService
{
    private readonly IRoleRepository _roleRepository;
    public RolesService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<RoleDto>> GetAll()
    {
        var roles = await _roleRepository.GetAll();
        return roles.Select(e=> new RoleDto{
            Id = e.Id,
            Name = e.Name
        });

    }

    public async Task<RoleDto> GetById(int id)
    {
        var role = await _roleRepository.GetById(id);
        if (role == null)
        {
            return null;
        }

        return new RoleDto{
            Id = role.Id,
            Name = role.Name
        };
    }

    public async Task Save(RoleDto roleDto)
    {
        var role = new Role{
            Name = roleDto.Name
        };

        await _roleRepository.Save(role);
    }

    public async Task Update(RoleDto roleDto)
    {
        var role = await _roleRepository.GetById(roleDto.Id);
        if (role != null)
        {
            role.Name = roleDto.Name;
            await _roleRepository.Update(role);
        }

    }

     public async Task Delete(int id)
    {
        await _roleRepository.Delete(id);
    }
}