using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _roleService.GetAll();
        return Ok(roles);
    }
    
    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var role = await _roleService.GetById(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] RoleDto roleDto){
        await _roleService.Save(roleDto);
        return CreatedAtAction(nameof(GetById), new {id = roleDto.Id},roleDto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] RoleDto roleDto)
    {
        if (id != roleDto.Id)
            return BadRequest();

        await _roleService.Update(roleDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _roleService.Delete(id);
        return NoContent();
    }
}