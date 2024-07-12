using JobSearch.Application.Repositories;
using JobSearch.Application.Repositories.Category;
using JobSearch.Application.Repositories.City;
using JobSearch.Application.Repositories.Company;
using JobSearch.Application.Repositories.JobType;
using JobSearch.Application.Repositories.Seniority;
using JobSearch.Infrastructure.Data;
using JobSearch.Infrastructure.Repositories.Category;
using JobSearch.Infrastructure.Repositories.City;
using JobSearch.Infrastructure.Repositories.Company;
using JobSearch.Infrastructure.Repositories.JobType;
using JobSearch.Infrastructure.Repositories.Seniority;

namespace JobSearch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Companies = new CompanyRepository(_context);
            Categories = new CategoryRepository(_context);
            Seniorities = new SeniorityRepository(_context);
            Cities = new CityRepository(_context);
            JobTypes = new JobTypeRepository(_context);

        }

        public ICompanyRepository Companies { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public ISeniorityRepository Seniorities { get; private set; }

        public ICityRepository Cities { get; private set; }

        public IJobTypeRepository JobTypes { get; private set; }

        public async Task Complete() => await _context.SaveChangesAsync();

        public async Task DisposeAsync() => await _context.DisposeAsync();
        public void Dispose() => _context.Dispose();


    }
}
