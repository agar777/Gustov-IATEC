using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize] 
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employee = await employeeService.GetAll();
        return Ok(employee);
    }
    
    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var employee = await employeeService.GetById(id);
        return employee is not null ? Ok(employee) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] EmployeeDto employeeDto){
        await employeeService.Save(employeeDto);
        return CreatedAtAction(nameof(GetById), new {id = employeeDto.Id},employeeDto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmployeeDto employeeDto)
    {
        if (id != employeeDto.Id)
            return BadRequest();

        await employeeService.Update(employeeDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await employeeService.Delete(id);
        return NoContent();
    }
}