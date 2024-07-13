using JobSearch.Application.Repositories.Currency;
using JobSearch.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Infrastructure.Repositories.Currency
{
    public class CurrencyWriteRepository : WriteRepository<JobSearch.Domain.Entities.Currency>, ICurrencyWriteRepository
    {
        public CurrencyWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
