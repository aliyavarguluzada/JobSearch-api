using JobSearch.Application.Repositories.Vacancy;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Vacancy
{
    public class VacancyReadRepository : ReadRepository<JobSearch.Domain.Entities.Vacancy>, IVacancyReadRepository
    {
        public VacancyReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
