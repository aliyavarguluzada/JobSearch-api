using JobSearch.Application.Repositories.Seniority;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Seniority
{
    public class SeniorityWriteRepository : WriteRepository<Domain.Entities.Seniority>, ISeniorityWriteRepository
    {
        public SeniorityWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
