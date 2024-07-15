using JobSearch.Application.Interfaces;
using JobSearch.Models.v1.Vacancy;
using MediatR;

namespace JobSearch.Application.Features.Vacancy.Query
{
    public class GetVacancyByIdQueryHandler : IRequestHandler<GetVacancyByIdQuery, GetVacancyDto>
    {
        private readonly IVacancyService _vacancyService;
        public GetVacancyByIdQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<GetVacancyDto> Handle(GetVacancyByIdQuery request, CancellationToken cancellationToken)
        => await _vacancyService.GetById(request.Id);
    }
}
