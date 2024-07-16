using Asp.Versioning;
using JobSearch.Application.CQRS.Vacancies.Command;
using JobSearch.Application.Features.Vacancy.Query;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Pagination;
using JobSearch.Models.v1.Vacancy;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/vacancy-management")]
    [ApiController]
    [ApiVersion(1)]
    public class VacancyController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("vacancies")]
        public async Task<ApiResult<CreateVacancyResponse>> Add([FromForm] VacancyRequest request) =>
            await Mediator.Send(new CreateVacancyCommand(request));

        [MapToApiVersion(1)]
        [HttpGet("vacancies")]
        public async Task<List<GetVacancyDto>> GetAll([FromQuery] PaginationModel model) =>
            await Mediator.Send(new GetAllVacancyQuery(model));

        [MapToApiVersion(1)]
        [HttpGet("vacancies/{id}")]
        public async Task<GetVacancyDto> GetById([FromRoute] int id) =>
            await Mediator.Send(new GetVacancyByIdQuery(id));
    }
}
