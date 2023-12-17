using WebApi.ProjectCompanyEmployee.Entities;
using WebApi.ProjectCompanyEmployee.Models;

namespace WebApi.ProjectCompanyEmployee.Services
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<(IEnumerable<Company>, PaginationMetadata)> GetAllCompaniesAsync(
            string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Company?> GetCompanyAsync(int id, bool includeEmployees);
        Task AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        Task<bool> CheckIfCompanyExistsByIdAsync(int companyId);
        Task<bool> CheckIfCompanyExistsByNameAsync(string companyName);
        Task<bool> SaveChangesAsync();
    }
}
