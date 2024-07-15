using JobSearch.Application.Repositories.Favorite;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Favorite
{
    public class FavoriteReadRepository : ReadRepository<JobSearch.Domain.Entities.Favorite>, IFavoriteReadRepository
    {
        public FavoriteReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
