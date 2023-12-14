using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.ProjectCompanyEmployee.Entities;

namespace WebApi.ProjectCompanyEmployee.DbContexts
{
    public class CompanyContext : DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Company
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Dummy Company 1",
                    Description = "This is a dummy company.",
                    Website = "https://www.dummycompany1.com",
                    Founded = DateTime.Now.AddYears(-10),
                    Industry = "Tech",
                    LogoUrl = "https://www.dummycompany1.com/logo.png"
                },
                new Company
                {
                    Id = 2,
                    Name = "Dummy Company 2",
                    Description = "This is another dummy company.",
                    Website = "https://www.dummycompany2.com",
                    Founded = DateTime.Now.AddYears(-5),
                    Industry = "Finance",
                    LogoUrl = "https://www.dummycompany2.com/logo.png"

                });

            // Seed data for Employee
            modelBuilder.Entity<Employee>()
                .HasData(
                new Employee
                {
                    ID = 1,
                    CompanyId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@dummycompany.com",
                    HiredOn = DateTime.Now.AddYears(-2),
                    Title = "Software Engineer",
                    Department = "Engineering"
                },
                new Employee
                {
                    ID = 2,
                    CompanyId = 1,
                    FirstName = "John 2",
                    LastName = "Doe 2",
                    Email = "john.doe@dummycompany.com",
                    HiredOn = DateTime.Now.AddYears(-1),
                    Title = "Software Engineer",
                    Department = "Engineering"
                },
                new Employee
                {
                    ID = 3,
                    CompanyId = 2,
                    FirstName = "John 3",
                    LastName = "Doe 3",
                    Email = "john.doe@dummycompany.com",
                    HiredOn = DateTime.Now.AddYears(-2),
                    Title = "Software Engineer",
                    Department = "Engineering"
                },
                new Employee
                {
                    ID = 4,
                    CompanyId = 2,
                    FirstName = "John 4",
                    LastName = "Doe 4",
                    Email = "john.doe@dummycompany.com",
                    HiredOn = DateTime.Now.AddYears(-1),
                    Title = "Software Engineer",
                    Department = "Engineering"
                }
              );
            base.OnModelCreating(modelBuilder);
        }
    }
}
