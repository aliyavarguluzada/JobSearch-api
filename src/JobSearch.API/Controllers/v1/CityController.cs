using Asp.Versioning;
using JobSearch.Application.Features.City.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.City;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/city-management")]
    [ApiController]
    [ApiVersion(1)]
    public class CityController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("cities")]
        public async Task<ApiResult<CreateCityResponse>> Add([FromForm] CityRequest request) =>
          await Mediator.Send(new CreateCityCommand(request));
    }
}
