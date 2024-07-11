using JobSearch.Application.Repositories;
using JobSearch.Application.Repositories.Category;
using JobSearch.Application.Repositories.Company;
using JobSearch.Infrastructure.Data;

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

        }

        public ICompanyRepository Companies { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();

    }
}
