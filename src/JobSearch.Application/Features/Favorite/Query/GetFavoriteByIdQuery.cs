using JobSearch.Models.v1.Favorite;
using MediatR;

namespace JobSearch.Application.Features.Favorite.Query
{
    public class GetFavoriteByIdQuery : IRequest<GetFavoriteDto>
    {
        public GetFavoriteByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
