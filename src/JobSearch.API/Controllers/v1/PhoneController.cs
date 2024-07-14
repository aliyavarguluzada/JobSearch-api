using JobSearch.Application.Features.Phone;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Phone;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/phones")]
    [ApiController]
    public class PhoneController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreatePhoneResponse>> Add(PhoneRequest request) =>
            await Mediator.Send(new CreatePhoneCommand(request));
    }
}
