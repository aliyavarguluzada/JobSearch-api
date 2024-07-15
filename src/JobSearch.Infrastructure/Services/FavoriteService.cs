using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Domain.Entities;
using JobSearch.Models.v1.Favorite;

namespace JobSearch.Infrastructure.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<CreateFavoriteResponse>> Add(FavoriteRequest request)
        {
            try
            {
                var favorite = new Favorite()
                {
                    CookieId = request.CookieId,
                    VacancyId = request.VacancyId,

                };

                await _unitOfWork.FavoritesWrite.AddAsync(favorite);
                await _unitOfWork.FavoritesWrite.SaveAsync();

                var response = new CreateFavoriteResponse()
                {
                    CookieId = favorite.CookieId,
                    VacancyId = favorite.VacancyId,
                    Id = favorite.Id
                };
                return ApiResult<CreateFavoriteResponse>.Ok(response);

            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateFavoriteResponse>.Error();
            }
        }
    }
}
