using JobSearch.Application.Result;
using JobSearch.Domain.Entities;
using JobSearch.Models.v1.Pagination;
using JobSearch.Models.v1.Vacancy;

namespace JobSearch.Application.Interfaces
{
    public interface IVacancyService
    {
        public Task<ApiResult<CreateVacancyResponse>> Add(VacancyRequest request);
        public Task<List<GetVacancyDto>> GetAll(PaginationModel model);
        public Task<GetVacancyDto> GetById(int id);
    }
}
