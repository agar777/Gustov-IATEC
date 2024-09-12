
public class CompanyService: ICompanyService
{

    private readonly ICompanyRepository _company;
    public CompanyService(ICompanyRepository company)
    {
        _company = company;        
    }

    public async Task<IEnumerable<CompanyDto>> GetAll()
    {
        var companies = await _company.GetAll();
        return companies.Select(e=>new CompanyDto{
            Id = e.Id,
            Name = e.Name
        });
    }

    public async Task<CompanyDto> GetById(int id)
    {
        var company = await _company.GetById(id);
        if (company == null)
        {
            return null;   
        }
        return new CompanyDto{
            Id = company.Id,
            Name = company.Name
        };
    }

    public async Task Save(CompanyDto companyDto)
    {
        var company = new Company{
            Name = companyDto.Name
        };

        await _company.Save(company);
    }

    public async Task Update(CompanyDto companyDto)
    {
        var company = await _company.GetById(companyDto.Id);
        if (company!=null)
        {
            company.Name = companyDto.Name;
            await _company.Update(company);
        }
    }
    public async Task Delete(int id)
    {
        await _company.Delete(id);
    }
}