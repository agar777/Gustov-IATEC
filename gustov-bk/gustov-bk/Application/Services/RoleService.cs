
public class RolesService: IRoleService
{
    private readonly IRoleRepository roleRepository;
    public RolesService(IRoleRepository roleRepository)
    {
        this.roleRepository = roleRepository;
    }

    public async Task<IEnumerable<RoleDto>> GetAll()
    {
        var roles = await roleRepository.GetAll();
        return roles.Select(e=> new RoleDto{
            Id = e.Id,
            Name = e.Name
        });

    }

    public async Task<RoleDto> GetById(int id)
    {
        var role = await roleRepository.GetById(id);
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

        await roleRepository.Save(role);
    }

    public async Task Update(RoleDto roleDto)
    {
        var role = await roleRepository.GetById(roleDto.Id);
        if (role != null)
        {
            role.Name = roleDto.Name;
            await roleRepository.Update(role);
        }

    }

     public async Task Delete(int id)
    {
        await roleRepository.Delete(id);
    }
}