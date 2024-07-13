using JobSearch.Application.Features.OperatorCode;
using JobSearch.Application.Result;
using JobSearch.Models.v1.OperatorCode;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/operatorCodes")]
    [ApiController]
    public class OperatorCodeController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateOperatorCodeResponse>> Add(OperatorCodeRequest request) =>
            await Mediator.Send(new CreateOperatorCodeCommand(request));
    }
}
