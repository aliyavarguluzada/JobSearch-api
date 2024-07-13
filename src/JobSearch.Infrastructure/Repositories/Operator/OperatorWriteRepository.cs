using JobSearch.Application.Repositories.Operator;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Operator
{
    public class OperatorWriteRepository : WriteRepository<JobSearch.Domain.Entities.Operator>, IOperatorWriteRepository
    {
        public OperatorWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
