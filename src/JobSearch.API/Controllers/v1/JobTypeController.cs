using JobSearch.Application.CQRS.JobType;
using JobSearch.Application.Result;
using JobSearch.Models.v1.JobType;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/jobTypes")]
    [ApiController]
    public class JobTypeController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateJobTypeResponse>> Add(JobTypeRequest request) =>
            await Mediator.Send(new CreateJobTypeCommand(request));
    }
}
