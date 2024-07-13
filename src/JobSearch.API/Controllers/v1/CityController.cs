using JobSearch.Application.Features.City.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.City;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateCityResponse>> Add(CityRequest request) =>
          await Mediator.Send(new CreateCityCommand(request));
    }
}
