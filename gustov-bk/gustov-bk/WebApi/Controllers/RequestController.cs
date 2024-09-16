using System.Net;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RequestController: ControllerBase
{
    private readonly IRequestService requestService;
    public RequestController(IRequestService requestService)
    {
        this.requestService = requestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var requests = await requestService.GetAll();
        return Ok(requests);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var request = requestService.GetById(id);
        if (request == null)
        {
            return NotFound();
        }
        return Ok(request);
    }
    
    [HttpPost]
    public async Task<IActionResult> SaveRequest([FromBody] RequestDto requestDto){
        try
        {
            await requestService.SaveRequest(requestDto);
            return CreatedAtAction(nameof(GetById), new { id = requestDto.Id }, requestDto);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}