using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
[Authorize] 
[ApiController]
[Route("api/[controller]")]
public class VacationController: ControllerBase
{
    private readonly IVacationService vacationService;
    public VacationController(IVacationService vacationService)
    {
        this.vacationService = vacationService;
    }

    [HttpGet("{requestId}")]

    public async Task<IActionResult> GetById(int requestId)
    {
        var vacation = await vacationService.GetById(requestId);        
        return vacation is not null ? Ok(vacation) : NotFound();

    }
    
    [HttpPost]
    public async Task<IActionResult> SaveVacation([FromBody] int requestId){
        try
        {
            await vacationService.SaveVacation(requestId);
            return Ok(new { success = "Vacation saved successfully." });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}