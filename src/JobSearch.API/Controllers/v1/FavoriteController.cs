using Asp.Versioning;
using JobSearch.Application.Features.Favorite.Command;
using JobSearch.Application.Features.Favorite.Query;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Favorite;
using JobSearch.Models.v1.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/favorite-management")]
    [ApiController]
    [ApiVersion(1)]
    public class FavoriteController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("favorites")]
        public async Task<ApiResult<CreateFavoriteResponse>> Add([FromBody] FavoriteRequest request) =>
            await Mediator.Send(new CreateFavoriteCommand(request));
        
        [MapToApiVersion(1)]
        [HttpGet("favorites")]
        public async Task<List<GetFavoriteDto>> GetAll([FromQuery] PaginationModel model) =>
            await Mediator.Send(new GetAllFavoritesQuery(model));

        [MapToApiVersion(1)]
        [HttpGet("favorite/{id}")]
        public async Task<GetFavoriteDto> GetById([FromRoute] int id) =>
            await Mediator.Send(new GetFavoriteByIdQuery(id));
    }
}
