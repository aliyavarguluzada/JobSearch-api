using JobSearch.Application.Result;
using JobSearch.Models.v1.Favorite;
using JobSearch.Models.v1.Pagination;

namespace JobSearch.Application.Interfaces
{
    public interface IFavoriteService
    {
        Task<ApiResult<CreateFavoriteResponse>> Add(FavoriteRequest request);
        Task<List<GetFavoriteDto>> GetAll(PaginationModel model);
        Task<GetFavoriteDto> GetById(int id);
    }
}
