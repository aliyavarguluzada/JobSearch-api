using JobSearch.Application.Repositories.Favorite;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Favorite
{
    public class FavoriteWriteRepistory : WriteRepository<JobSearch.Domain.Entities.Favorite>, IFavoriteWriteRepository
    {
        public FavoriteWriteRepistory(ApplicationDbContext context) : base(context)
        {
        }
    }
}
