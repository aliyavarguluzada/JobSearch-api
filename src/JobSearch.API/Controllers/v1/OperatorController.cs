using JobSearch.Application.Features.Operator.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Operator;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/operators")]
    [ApiController]
    public class OperatorController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateOperatorResponse>> Add(OperatorRequest request) =>
            await Mediator.Send(new CreateOperatorCommand(request));
    }
}
