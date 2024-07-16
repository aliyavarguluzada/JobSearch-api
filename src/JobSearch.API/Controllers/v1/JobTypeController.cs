using Asp.Versioning;
using JobSearch.Application.Features.JobType.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.JobType;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/jobType-management")]
    [ApiController]
    [ApiVersion(1)]
    public class JobTypeController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("jobTypes")]
        public async Task<ApiResult<CreateJobTypeResponse>> Add([FromForm] JobTypeRequest request) =>
            await Mediator.Send(new CreateJobTypeCommand(request));
    }
}
