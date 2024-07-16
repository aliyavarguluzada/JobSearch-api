using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Domain.Entities;
using JobSearch.Models.v1.Favorite;
using JobSearch.Models.v1.Pagination;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Infrastructure.Services
{
    public class FavoriteService : BaseService, IFavoriteService
    {
        public FavoriteService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        public async Task<ApiResult<CreateFavoriteResponse>> Add(FavoriteRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var favorite = new Favorite()
                {
                    CookieId = request.CookieId,
                    VacancyId = request.VacancyId,

                };

                await _unitOfWork.FavoritesWrite.AddAsync(favorite);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.FavoritesWrite.Complete();

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
            finally
            {
                await _unitOfWork.DisposeAsync();
            }
        }

        public async Task<List<GetFavoriteDto>> GetAll(PaginationModel model)
        {

            try
            {
                var favorites = await _unitOfWork.FavoritesRead.Table
                    .Include(c => c.Vacancy)
                    .AsNoTracking()
                    .Select(c => new GetFavoriteDto
                    {
                        VacancyName = c.Vacancy.Name,
                        CookieId = c.CookieId,
                        VacancyId = c.VacancyId,
                        Id = c.Id
                    })
                    .ToListAsync();

                return favorites;

            }
            catch (Exception)
            {
                return new List<GetFavoriteDto>();
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }
        }

        public async Task<GetFavoriteDto> GetById(int id)
        {
            try
            {
                var fav = await _unitOfWork.FavoritesRead.Table
               .AsNoTracking()
               .Where(c => c.Id == id)
               .Include(c => c.Vacancy)
               .FirstOrDefaultAsync();

                var dto = new GetFavoriteDto
                {
                    CookieId = fav.CookieId,
                    Id = fav.Id,
                    VacancyId = fav.VacancyId,
                    VacancyName = fav.Vacancy.Name
                };
                return dto;
            }
            catch (Exception)
            {
                return new GetFavoriteDto();
            }
            finally
            {
                await _unitOfWork.DisposeAsync();

            }


        }
    }
}
