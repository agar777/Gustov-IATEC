using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
[Authorize] 
[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService roleService;
    public RoleController(IRoleService roleService)
    {
        this.roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await roleService.GetAll();
        return Ok(roles);
    }
    
    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var role = await roleService.GetById(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] RoleDto roleDto){
        await roleService.Save(roleDto);
        return CreatedAtAction(nameof(GetById), new {id = roleDto.Id},roleDto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] RoleDto roleDto)
    {
        if (id != roleDto.Id)
            return BadRequest();

        await roleService.Update(roleDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await roleService.Delete(id);
        return NoContent();
    }
}