using Asp.Versioning;
using JobSearch.Application.Features.OperatorCode;
using JobSearch.Application.Result;
using JobSearch.Models.v1.OperatorCode;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/operatorCode-management")]
    [ApiController]
    [ApiVersion(1)]
    public class OperatorCodeController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("operatorCodes")]
        public async Task<ApiResult<CreateOperatorCodeResponse>> Add([FromForm] OperatorCodeRequest request) =>
            await Mediator.Send(new CreateOperatorCodeCommand(request));
    }
}
