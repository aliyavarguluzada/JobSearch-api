using JobSearch.Application.Features.Seniority.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Seniority;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/seniorities")]
    [ApiController]
    public class SeniorityController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateSeniorityResponse>> Add([FromForm] SeniorityRequest request) =>
            await Mediator.Send(new CreateSeniorityCommand(request));
    }
}
