using JobSearch.Application.Repositories;
using JobSearch.Application.Repositories.Salary;
using JobSearch.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Infrastructure.Repositories.Salary
{
    public class SalaryWriteRepository : WriteRepository<JobSearch.Domain.Entities.Salary>, ISalaryWriteRepository
    {
        public SalaryWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
