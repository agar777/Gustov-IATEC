using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
[Authorize] 
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = await userService.GetAll();
        return Ok(user);
    }
    
    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var user = await userService.GetById(id);
        return user is not null ? Ok(user) : NotFound();

    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] UserDto userDto){
        await userService.Save(userDto);
        return CreatedAtAction(nameof(GetById), new {id = userDto.Id},userDto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserDto userDto)
    {
        if (id != userDto.Id)
            return BadRequest();

        await userService.Update(userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await userService.Delete(id);
        return NoContent();
    }
}