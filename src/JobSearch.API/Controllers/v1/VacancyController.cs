using JobSearch.Application.CQRS.Vacancies.Command;
using JobSearch.Application.Features.Vacancy.Query;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Vacancy;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/vacancies")]
    [ApiController]
    public class VacancyController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateVacancyResponse>> Add(VacancyRequest request) =>
          await Mediator.Send(new CreateVacancyCommand(request));

        [HttpGet("getAll")]
        public async Task<List<GetAllVacanciesDto>> GetAll()
            => await Mediator.Send(new GetAllVacancyQuery());
    }
}
