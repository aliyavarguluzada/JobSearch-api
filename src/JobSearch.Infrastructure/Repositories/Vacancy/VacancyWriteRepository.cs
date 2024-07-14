using JobSearch.Application.Repositories;
using JobSearch.Application.Repositories.Vacancy;
using JobSearch.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Infrastructure.Repositories.Vacancy
{
    public class VacancyWriteRepository : WriteRepository<JobSearch.Domain.Entities.Vacancy>, IVacancyWriteRepository
    {
        public VacancyWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
