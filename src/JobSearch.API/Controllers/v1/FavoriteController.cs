using JobSearch.Application.Features.Favorite.Command;
using JobSearch.Application.Features.Favorite.Query;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Favorite;
using JobSearch.Models.v1.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/favorites")]
    [ApiController]
    public class FavoriteController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateFavoriteResponse>> Add([FromBody] FavoriteRequest request) =>
            await Mediator.Send(new CreateFavoriteCommand(request));

        [HttpGet("getAll")]
        public async Task<List<GetFavoriteDto>> GetAll([FromQuery] PaginationModel model) =>
            await Mediator.Send(new GetAllFavoritesQuery(model));
        [HttpGet("getById/{id}")]
        public async Task<GetFavoriteDto> GetById([FromRoute] int id) =>
            await Mediator.Send(new GetFavoriteByIdQuery(id));
    }
}
