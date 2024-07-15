using JobSearch.Application.Features.Currency.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Currency;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateCurrencyResponse>> Add([FromForm] CurrencyRequest request) =>
            await Mediator.Send(new CreateCurrencyCommand(request));
    }
}
