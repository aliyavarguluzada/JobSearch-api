using JobSearch.Application.Repositories.OpportunityType;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.OpportunityType
{
    public class OpportunityTypeRepository : WriteRepository<JobSearch.Domain.Entities.OpportunityType>, IOpportunityTypeRepository
    {
        public OpportunityTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
