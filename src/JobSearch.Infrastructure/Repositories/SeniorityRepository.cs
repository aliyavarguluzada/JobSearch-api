using JobSearch.Application.Repositories.Seniority;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories
{
    public class SeniorityRepository : Repository<JobSearch.Domain.Entities.Seniority>, ISeniorityRepository
    {
        public SeniorityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
