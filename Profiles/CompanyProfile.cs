using AutoMapper;
using WebApi.ProjectCompanyEmployee.Entities;

namespace WebApi.ProjectCompanyEmployee.Profiles
{
    public class CompanyProfile:Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, Models.CompanyDtoWithOutEmployees>();
            CreateMap<Company, Models.CompanyDto>();
            CreateMap<Company, Models.CompanyForUpdateDto>();

            CreateMap<Models.CompanyForCreationDto, Company>();
            CreateMap<Models.CompanyForUpdateDto, Company>();



        }       
    }
}
