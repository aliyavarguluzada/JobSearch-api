using Asp.Versioning;
using JobSearch.Application.Features.Seniority.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Seniority;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/seniority-management")]
    [ApiController]
    [ApiVersion(1)]
    public class SeniorityController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("seniorities")]
        public async Task<ApiResult<CreateSeniorityResponse>> Add([FromForm] SeniorityRequest request) =>
            await Mediator.Send(new CreateSeniorityCommand(request));
    }
}
