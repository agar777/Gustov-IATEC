using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = await _userService.GetAll();
        return Ok(user);
    }
    
    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] UserDto userDto){
        await _userService.Save(userDto);
        return CreatedAtAction(nameof(GetById), new {id = userDto.Id},userDto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserDto userDto)
    {
        if (id != userDto.Id)
            return BadRequest();

        await _userService.Update(userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.Delete(id);
        return NoContent();
    }
}