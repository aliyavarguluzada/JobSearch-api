using JobSearch.Application.Repositories.JobType;
using JobSearch.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Infrastructure.Repositories.JobType
{
    public class JobTypeRepository : WriteRepository<JobSearch.Domain.Entities.JobType>, IJobTypeRepository
    {
        public JobTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
