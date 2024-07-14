using JobSearch.Application.Features.Address;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Address;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateAddressResponse>> Add(AddressRequest request) =>
            await Mediator.Send(new CreateAddressCommand(request));
    }
}
