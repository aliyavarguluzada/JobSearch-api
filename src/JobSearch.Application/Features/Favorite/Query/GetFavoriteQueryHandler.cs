using JobSearch.Application.Interfaces;
using JobSearch.Models.v1.Favorite;
using MediatR;

namespace JobSearch.Application.Features.Favorite.Query
{
    public class GetFavoriteQueryHandler : IRequestHandler<GetFavoriteByIdQuery, GetFavoriteDto>
    {
        private readonly IFavoriteService _favoriteService;

        public GetFavoriteQueryHandler(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        public async Task<GetFavoriteDto> Handle(GetFavoriteByIdQuery request, CancellationToken cancellationToken)
        => await _favoriteService.GetById(request.Id);

    }
}
