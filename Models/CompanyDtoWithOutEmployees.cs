using System.ComponentModel.DataAnnotations;
using WebApi.ProjectCompanyEmployee.Entities;

namespace WebApi.ProjectCompanyEmployee.Models
{
    public class CompanyDtoWithOutEmployees
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ?Website { get; set; }

        public DateTime Founded { get; set; }

        public string ?Industry { get; set; }

        public string ?LogoUrl { get; set; }

        //public ICollection<EmployeeDto> Employees { get; set; }
        //   = new List<EmployeeDto>();
    }
}
