using JobSearch.Application.Repositories.Category;
using JobSearch.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Infrastructure.Repositories.Category
{
    public class CategoryRepository : WriteRepository<Domain.Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
