using JobSearch.Models.v1.Favorite;
using JobSearch.Models.v1.Pagination;
using MediatR;

namespace JobSearch.Application.Features.Favorite.Query
{
    public class GetAllFavoritesQuery : IRequest<List<GetFavoriteDto>>
    {
        public GetAllFavoritesQuery(PaginationModel model)
        {
            Model = model;
        }
        public PaginationModel Model { get; set; }
    }
}
