using JobSearch.Application.Repositories.Company;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<JobSearch.Domain.Entities.Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
