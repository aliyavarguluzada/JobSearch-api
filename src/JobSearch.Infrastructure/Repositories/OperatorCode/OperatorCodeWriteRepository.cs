using JobSearch.Application.Repositories.OperatorCode;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.OperatorCode
{
    public class OperatorCodeWriteRepository : WriteRepository<JobSearch.Domain.Entities.OperatorCode>, IOperatorCodeWriteRepository
    {
        public OperatorCodeWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
