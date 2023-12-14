using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ProjectCompanyEmployee.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Url]
        public string? Website { get; set; }

        [Required]
        public DateTime Founded { get; set; }

        [StringLength(50)]
        public string? Industry { get; set; }

        public string? LogoUrl { get; set; }

        public ICollection<Employee> Employees { get; set; }
              = new List<Employee>();
    }
}
