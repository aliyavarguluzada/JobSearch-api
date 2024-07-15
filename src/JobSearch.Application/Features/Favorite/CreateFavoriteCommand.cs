using JobSearch.Application.Result;
using JobSearch.Models.v1.Favorite;
using MediatR;

namespace JobSearch.Application.Features.Favorite
{
    public class CreateFavoriteCommand : IRequest<ApiResult<CreateFavoriteResponse>>
    {
        public CreateFavoriteCommand(FavoriteRequest request)
        {
            FavoriteRequest = request;
        }
        public FavoriteRequest FavoriteRequest { get; set; }
    }
}
