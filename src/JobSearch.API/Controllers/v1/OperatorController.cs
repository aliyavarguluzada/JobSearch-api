using Asp.Versioning;
using JobSearch.Application.Features.Operator.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Operator;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/operator-management")]
    [ApiController]
    [ApiVersion(1)]
    public class OperatorController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("operators")]
        public async Task<ApiResult<CreateOperatorResponse>> Add([FromForm] OperatorRequest request) =>
            await Mediator.Send(new CreateOperatorCommand(request));
    }
}
