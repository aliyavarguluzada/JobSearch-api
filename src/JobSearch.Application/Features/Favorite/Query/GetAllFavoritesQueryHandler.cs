using JobSearch.Application.Interfaces;
using JobSearch.Models.v1.Favorite;
using MediatR;

namespace JobSearch.Application.Features.Favorite.Query
{
    public class GetAllFavoritesQueryHandler : IRequestHandler<GetAllFavoritesQuery, List<GetFavoriteDto>>
    {
        private readonly IFavoriteService _favoriteService;

        public GetAllFavoritesQueryHandler(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        public async Task<List<GetFavoriteDto>> Handle(GetAllFavoritesQuery request, CancellationToken cancellationToken)
        => await _favoriteService.GetAll(request.Model);

    }
}
