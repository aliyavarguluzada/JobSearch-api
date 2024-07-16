using Asp.Versioning;
using JobSearch.Application.Features.Salary;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Salary;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/salary-management")]
    [ApiController]
    [ApiVersion(1)]
    public class SalaryController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("salaries")]
        public async Task<ApiResult<CreateSalaryResponse>> Add([FromForm] SalaryRequest request) =>
            await Mediator.Send(new CreateSalaryCommand(request));
    }
}
