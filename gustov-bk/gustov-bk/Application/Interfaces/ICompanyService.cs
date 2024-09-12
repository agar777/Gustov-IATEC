public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAll();
    Task<CompanyDto> GetById(int id);
    Task Save(CompanyDto companyDto);
    Task Update(CompanyDto companyDto);
    Task Delete(int id);
}