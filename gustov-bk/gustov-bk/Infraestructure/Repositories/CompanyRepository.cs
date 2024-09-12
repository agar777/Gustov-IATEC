
using Microsoft.EntityFrameworkCore;

public class CompanyRepository: ICompanyRepository
{
    private readonly GustovContext _context;
    public CompanyRepository(GustovContext context)
    {
        _context = context;
    }

     public async Task<IEnumerable<Company>> GetAll()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company> GetById(int id)
    {
        return await _context.Companies.FindAsync(id);
    }

    public async Task Save(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Company company)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company!=null)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}