using Asp.Versioning;
using JobSearch.Application.Features.Address;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Address;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/address-management")]
    [ApiController]
    [ApiVersion(1)]
    public class AddressController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("addresses")]
        public async Task<ApiResult<CreateAddressResponse>> Add([FromForm] AddressRequest request) =>
            await Mediator.Send(new CreateAddressCommand(request));
    }
}
