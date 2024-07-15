using JobSearch.Models.v1.Vacancy;
using MediatR;

namespace JobSearch.Application.Features.Vacancy.Query
{
    public class GetVacancyByIdQuery : IRequest<GetVacancyDto>
    {
        public GetVacancyByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
