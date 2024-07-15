using JobSearch.Application.Features.Favorite;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Favorite;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/favorites")]
    [ApiController]
    public class FavoriteController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateFavoriteResponse>> Add(FavoriteRequest request) =>
            await Mediator.Send(new CreateFavoriteCommand(request));
    }
}
