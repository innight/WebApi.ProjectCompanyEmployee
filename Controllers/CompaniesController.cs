using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.ProjectCompanyEmployee.DbContexts;
using WebApi.ProjectCompanyEmployee.Entities;
using WebApi.ProjectCompanyEmployee.Models;
using WebApi.ProjectCompanyEmployee.Services;
using System.Text.Json;

namespace WebApi.ProjectCompanyEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMapper _mapper;
        const int maxCompaniesPageSize = 20;

        private readonly IServiceCompany _serviceCompany;

        public CompaniesController(IServiceCompany serviceCompany, IMapper mapper)
        {
            _serviceCompany = serviceCompany ??
                throw new ArgumentNullException(nameof(serviceCompany));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //// GET: api/Companies
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CompanyDtoWithOutEmployees>>> GetCompanyAsync()
        //{
        //    try
        //    {
        //        IEnumerable<Company> companyEntities = await _companyRepository.GetAllCompaniesAsync();
        //        return Ok(_mapper.Map<IEnumerable<CompanyDtoWithOutEmployees>>(companyEntities));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { error = "Failed to get companies." + ex.Message });
        //    }
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDtoWithOutEmployees>>> GetCompanyAsync(
            string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                if (pageSize > maxCompaniesPageSize)
                {
                    pageSize = maxCompaniesPageSize;
                }

                var (companyEntities, paginationMetadata) = await _serviceCompany.GetAllCompaniesAsync(name, searchQuery, pageNumber, pageSize);

                Response.Headers.Add("X-Pagination",
                    JsonSerializer.Serialize(paginationMetadata));

                return Ok(_mapper.Map<IEnumerable<CompanyDtoWithOutEmployees>>(companyEntities));
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to get companies." + ex.Message });
            }
        }

        // GET: api/Companies/5
        [HttpGet("{id}", Name = "GetCompany")]
        public async Task<ActionResult<Company>> GetCompany(
            int id, bool includeEmployees = false)
        {
            try
            {
                var company = await _serviceCompany.GetCompanyAsync(id, includeEmployees);

                if (company is null)
                {
                    return NotFound();
                }

                if (includeEmployees)
                {
                    return Ok(_mapper.Map<CompanyDto>(company));
                }

                return Ok(_mapper.Map<CompanyDtoWithOutEmployees>(company));
            }
            catch (Exception ex)
            {
                return Problem($"Exception thrown: {ex.Message}");
            }
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{companyId}")]
        public async Task<IActionResult> PutCompany(int companyId, CompanyForUpdateDto company)
        {
            if (!await _serviceCompany.CheckIfCompanyExistsByIdAsync(companyId))
            {
                return NotFound();
            }

            var companyEntity = await _serviceCompany
                .GetCompanyAsync(companyId, false);
            if (companyEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(company, companyEntity);

            await _serviceCompany.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyDtoWithOutEmployees>> PostCompany(
            CompanyForCreationDto company)
        {
            var finalCompany = _mapper.Map<Company>(company);

            // Verifica se a empresa já existe
            var companyExists = await _serviceCompany.CheckIfCompanyExistsByNameAsync(company.Name);

            if (companyExists)
            {
                return BadRequest("A empresa já existe.");
            }

            await _serviceCompany.AddCompany(finalCompany);    

            await _serviceCompany.SaveChangesAsync();

            // Obtenha o ID gerado automaticamente após salvar as alterações
            var generatedId = finalCompany.Id;

            return CreatedAtAction("GetCompany", new { id = generatedId }, _mapper.Map<CompanyDtoWithOutEmployees>(finalCompany));
        }

        // DELETE: api/Companies/5
        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            //return NoContent();
            if (!await _serviceCompany.CheckIfCompanyExistsByIdAsync(companyId))
            {
                return NotFound();
            }

            var company = await _serviceCompany.GetCompanyAsync(companyId, false);
            if (company == null)
            {
                return NotFound();
            }

            _serviceCompany.DeleteCompany(company);
            await _serviceCompany.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{companyId}")]
        public async Task<ActionResult> PatchCompany(int companyId, JsonPatchDocument<CompanyForUpdateDto> patchDoc)
        {
            if (!await _serviceCompany.CheckIfCompanyExistsByIdAsync(companyId))
            {
                return NotFound();
            }

            var companyEntity = await _serviceCompany
                .GetCompanyAsync(companyId, false);
            if (companyEntity == null)
            {
                return NotFound();
            }

            var companyToPatch = _mapper.Map<CompanyForUpdateDto>(
               companyEntity);


            patchDoc.ApplyTo(companyToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(companyToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(companyToPatch, companyEntity);
            await _serviceCompany.SaveChangesAsync();

            return NoContent();
        }
    }
}
