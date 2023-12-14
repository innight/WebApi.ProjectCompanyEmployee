namespace WebApi.ProjectCompanyEmployee.Models
{
    public class EmployeeDto
    {
        int ID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime HiredOn { get; set; }

        public string ?Title { get; set; }

        public string ?Department { get; set; }
    }
}
