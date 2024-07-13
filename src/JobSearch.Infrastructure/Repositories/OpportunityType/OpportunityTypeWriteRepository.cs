using JobSearch.Application.Repositories.OpportunityType;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.OpportunityType
{
    public class OpportunityTypeWriteRepository : WriteRepository<JobSearch.Domain.Entities.OpportunityType>, IOpportunityTypeWriteRepository
    {
        public OpportunityTypeWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
