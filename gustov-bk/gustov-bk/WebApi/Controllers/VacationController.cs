using System.Net;
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
    public async Task<IActionResult> SaveVacation([FromBody] int requestId){
        try
        {
            await vacationService.SaveVacation(requestId);
            return Ok(new { message = "Vacation saved successfully." });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}