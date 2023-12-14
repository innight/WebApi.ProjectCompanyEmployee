using WebApi.ProjectCompanyEmployee.Entities;
using WebApi.ProjectCompanyEmployee.Models;

namespace WebApi.ProjectCompanyEmployee.Services
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyAsync(int id);
        Task AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int companyId);
        Task<bool> CompanyExistsAsync(int companyId);
        Task<bool> SaveChangesAsync();
    }
}
