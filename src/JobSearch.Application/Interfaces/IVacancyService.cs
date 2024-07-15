using JobSearch.Application.Result;
using JobSearch.Models.v1.Pagination;
using JobSearch.Models.v1.Vacancy;

namespace JobSearch.Application.Interfaces
{
    public interface IVacancyService
    {
        Task<ApiResult<CreateVacancyResponse>> Add(VacancyRequest request);
        Task<List<GetVacancyDto>> GetAll(PaginationModel model);
        Task<GetVacancyDto> GetById(int id);
    }
}
