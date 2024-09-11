public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAll();
    Task<Company> GetById(int id);
    Task Save(Company company);
    Task Update(int id, Company company);
    Task Delete(int id);
}