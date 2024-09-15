using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VacationController: ControllerBase
{
    private readonly IVacationService vacationService;
    public VacationController(IVacationService vacationService)
    {
        this.vacationService = vacationService;
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var vacation = await vacationService.GetById(id);
        if (vacation == null)
        {
            return NotFound();
        }
        return Ok(vacation);
    }
    
    [HttpPost]
    public async Task<IActionResult> Savevacation([FromBody] VacationDto vacationDto){
        await vacationService.SaveVacation(vacationDto);
        return CreatedAtAction(nameof(GetById), new {id = vacationDto.Id},vacationDto);
    }
}