using JobSearch.Application.Repositories.City;
using JobSearch.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Infrastructure.Repositories.City
{
    public class CityWriteRepository : WriteRepository<Domain.Entities.City>, ICityWriteRepository
    {
        public CityWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
