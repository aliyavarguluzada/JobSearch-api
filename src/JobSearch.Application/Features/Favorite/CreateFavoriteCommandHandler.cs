using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Favorite;
using MediatR;

namespace JobSearch.Application.Features.Favorite
{
    public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand, ApiResult<CreateFavoriteResponse>>
    {
        private readonly IFavoriteService _favoriteService;

        public CreateFavoriteCommandHandler(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        public async Task<ApiResult<CreateFavoriteResponse>> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
        => await _favoriteService.Add(request.FavoriteRequest);
    }
}
