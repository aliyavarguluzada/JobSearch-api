using JobSearch.Application.Repositories.Seniority;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Seniority
{
    public class SeniorityRepository : Repository<Domain.Entities.Seniority>, ISeniorityRepository
    {
        public SeniorityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
