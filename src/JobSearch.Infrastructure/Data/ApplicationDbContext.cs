using JobSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobSearch.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
       

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<OperatorCode> OperatorCodes { get; set; }  
        public DbSet<OpportunityType> OpportunityTypes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Seniority> Seniorities { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
    }
}
