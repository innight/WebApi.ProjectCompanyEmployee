using WebApi.ProjectCompanyEmployee.Entities;

namespace WebApi.ProjectCompanyEmployee.Services
{
    public interface IServiceCompany
    {
        Task AddCompany(Company company);
        Task<bool> CheckIfCompanyExistsByIdAsync(int companyId);
        Task<bool> CheckIfCompanyExistsByNameAsync(string companyName);
        void DeleteCompany(Company company);
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<(IEnumerable<Company>, PaginationMetadata)> GetAllCompaniesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Company?> GetCompanyAsync(int companyId, bool includeEmployees = false);
        Task<bool> SaveChangesAsync();
        void UpdateCompany(Company company);
    }
}
