using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CompanyController: ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await _companyService.GetAll();
        return Ok(companies);
    }
    
    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var company = await _companyService.GetById(id);
        if (company == null)
        {
            return NotFound();
        }
        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] CompanyDto companyDto){
        await _companyService.Save(companyDto);
        return CreatedAtAction(nameof(GetById), new {id = companyDto.Id},companyDto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CompanyDto companyDto)
    {
        if (id != companyDto.Id)
            return BadRequest();

        await _companyService.Update(companyDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _companyService.Delete(id);
        return NoContent();
    }
}