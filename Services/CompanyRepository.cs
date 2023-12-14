using Microsoft.EntityFrameworkCore;
using WebApi.ProjectCompanyEmployee.DbContexts;
using WebApi.ProjectCompanyEmployee.Entities;

namespace WebApi.ProjectCompanyEmployee.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext _context;

        public CompanyRepository(CompanyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task AddCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CompanyExistsAsync(int companyId)
        {
            return await _context.Companies.AnyAsync(c => c.Id == companyId);
        }

        public void DeleteCompany(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _context.Companies.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Company?> GetCompanyAsync(int id)
        {
            return await _context.Companies
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
