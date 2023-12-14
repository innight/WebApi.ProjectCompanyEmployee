using AutoMapper;
using WebApi.ProjectCompanyEmployee.Entities;
using WebApi.ProjectCompanyEmployee.Models;

namespace WebApi.ProjectCompanyEmployee.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
