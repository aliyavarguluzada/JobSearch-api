using Asp.Versioning;
using JobSearch.Application.Features.Phone;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Phone;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/phone-management")]
    [ApiController]
    [ApiVersion(1)]
    public class PhoneController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("phones")]
        public async Task<ApiResult<CreatePhoneResponse>> Add([FromForm] PhoneRequest request) =>
            await Mediator.Send(new CreatePhoneCommand(request));
    }
}
