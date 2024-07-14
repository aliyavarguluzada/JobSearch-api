using JobSearch.Application.Result;
using JobSearch.Models.v1.Vacancy;

namespace JobSearch.Application.Interfaces
{
    public interface IVacancyService
    {
        public Task<ApiResult<CreateVacancyResponse>> Add(VacancyRequest request);
        public Task<List<GetAllVacanciesDto>> GetAll();
    }
}
