using System.ComponentModel.Design;
using WebApi.ProjectCompanyEmployee.Entities;

namespace WebApi.ProjectCompanyEmployee.Services
{
    public class ServiceCompany : IServiceCompany
    {
        private readonly ICompanyRepository _companyRepository;

        public ServiceCompany(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        public async Task AddCompany(Company company)
        {
            await _companyRepository.AddCompany(company);
        }

        public async Task<bool> CheckIfCompanyExistsByIdAsync(int companyId)
        {
            return await _companyRepository.CheckIfCompanyExistsByIdAsync(companyId);
        }

        public async Task<bool> CheckIfCompanyExistsByNameAsync(string companyName)
        {
            return await _companyRepository.CheckIfCompanyExistsByNameAsync(companyName);
        }

        public void DeleteCompany(Company company)
        {
            _companyRepository.DeleteCompany(company);
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _companyRepository.GetAllCompaniesAsync();
        }

        public async Task<(IEnumerable<Company>, PaginationMetadata)> GetAllCompaniesAsync(string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            return await _companyRepository.GetAllCompaniesAsync(name, searchQuery, pageNumber, pageSize);
        }

        public async Task<Company?> GetCompanyAsync(int companyId, bool includeEmployees)
        {
            return await _companyRepository.GetCompanyAsync(companyId, includeEmployees);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _companyRepository.SaveChangesAsync();
        }

        public void UpdateCompany(Company company)
        {
            _companyRepository.UpdateCompany(company);
        }
    }
}
