using System.ComponentModel.DataAnnotations;
using WebApi.ProjectCompanyEmployee.Entities;

namespace WebApi.ProjectCompanyEmployee.Models
{
    public class CompanyForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string ?Website { get; set; }

        [Required(ErrorMessage = "You should provide a date value.")]
        public DateTime Founded { get; set; }

        public string ?Industry { get; set; }

        public string ?LogoUrl { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; }
           = new List<EmployeeDto>();
    }
}
