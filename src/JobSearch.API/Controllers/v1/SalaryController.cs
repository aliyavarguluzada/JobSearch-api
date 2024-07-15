using JobSearch.Application.Features.Salary;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Salary;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/salaries")]
    [ApiController]
    public class SalaryController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateSalaryResponse>> Add([FromForm] SalaryRequest request) =>
            await Mediator.Send(new CreateSalaryCommand(request));
    }
}
