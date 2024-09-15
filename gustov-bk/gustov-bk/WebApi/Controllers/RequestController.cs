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
        await requestService.SaveRequest(requestDto);
        return CreatedAtAction(nameof(GetById), new {id = requestDto.Id},requestDto);
    }
}