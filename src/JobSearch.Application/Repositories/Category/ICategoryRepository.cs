using JobSearch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Application.Repositories.Category
{
    public interface ICategoryRepository : IRepository<JobSearch.Domain.Entities.Category>
    {
    }
}
