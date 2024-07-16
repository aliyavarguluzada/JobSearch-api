using Asp.Versioning;
using JobSearch.Application.Features.Currency.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Currency;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/currency-management")]
    [ApiController]
    [ApiVersion(1)]
    public class CurrencyController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("currencies")]
        public async Task<ApiResult<CreateCurrencyResponse>> Add([FromForm] CurrencyRequest request) =>
            await Mediator.Send(new CreateCurrencyCommand(request));
    }
}
