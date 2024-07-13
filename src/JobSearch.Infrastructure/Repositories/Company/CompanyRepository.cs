using JobSearch.Application.Repositories.Company;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Company
{
    public class CompanyRepository : WriteRepository<Domain.Entities.Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
