using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.ProjectCompanyEmployee.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(150)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public required string Email { get; set; }

        [Required]
        public DateTime HiredOn { get; set; }

        public string ?Title { get; set; }
        
        [MaxLength(75)]
        public string ?Department { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        public int CompanyId { get; set; }
    }
}
