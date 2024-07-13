using JobSearch.Application.Repositories.Company;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Company
{
    public class CompanyWriteRepository : WriteRepository<Domain.Entities.Company>, ICompanyWriteRepository
    {
        public CompanyWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
