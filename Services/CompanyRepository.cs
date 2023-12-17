using System.ComponentModel.Design;
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
        public async Task AddCompany(Company company)
        {
            // Verifica se a empresa já existe pelo Name
            var companyExistsByName = await CheckIfCompanyExistsByNameAsync(company.Name);

            // Se a empresa não existir, adiciona ao banco de dados
            if (companyExistsByName)
            {
                // Lança uma exceção ou retorna um valor que indique que a empresa já existe
                throw new Exception("A empresa já existe.");
            }
            await _context.Companies.AddAsync(company);
        }

        public async Task<bool> CheckIfCompanyExistsByIdAsync(int companyId)
        {
            // Retorna true se a empresa existir, false caso contrário
            return await _context.Companies.AnyAsync(c => c.Id == companyId);
        }

        public async Task<bool> CheckIfCompanyExistsByNameAsync(string companyName)
        {
            // Retorna true se a empresa existir, false caso contrário
            return await _context.Companies.AnyAsync(c => c.Name == companyName);
        }

        public void DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _context.Companies.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<(IEnumerable<Company>, PaginationMetadata)> GetAllCompaniesAsync(
            string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            // collection to start from
            var collection = _context.Companies as IQueryable<Company>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery)
                    || (a.Description != null && a.Description.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(c => c.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }

        public async Task<Company?> GetCompanyAsync(int companyId, bool includeEmployees = false)
        {
            if (includeEmployees)
            {
                return await _context.Companies.Include(c => c.Employees)
                    .Where(c => c.Id == companyId).FirstOrDefaultAsync();
            }

            return await _context.Companies
                .Where(c => c.Id == companyId)
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
