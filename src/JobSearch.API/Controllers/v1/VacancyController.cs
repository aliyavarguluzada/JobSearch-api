using JobSearch.Application.CQRS.Vacancies.Command;
using JobSearch.Application.Features.Vacancy.Query;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Pagination;
using JobSearch.Models.v1.Vacancy;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/vacancies")]
    [ApiController]
    public class VacancyController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateVacancyResponse>> Add([FromForm] VacancyRequest request) =>
            await Mediator.Send(new CreateVacancyCommand(request));

        [HttpGet("getAll")]
        public async Task<List<GetVacancyDto>> GetAll([FromQuery] PaginationModel model) =>
            await Mediator.Send(new GetAllVacancyQuery(model));

        [HttpGet("getById/{id}")]
        public async Task<GetVacancyDto> GetById([FromRoute] int id) =>
            await Mediator.Send(new GetVacancyByIdQuery(id));
    }
}
