using JobSearch.Application.Result;
using JobSearch.Models.v1.Favorite;

namespace JobSearch.Application.Interfaces
{
    public interface IFavoriteService
    {
        public Task<ApiResult<CreateFavoriteResponse>> Add(FavoriteRequest request);
    }
}
