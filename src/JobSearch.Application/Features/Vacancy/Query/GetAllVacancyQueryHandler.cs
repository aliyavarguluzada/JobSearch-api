using JobSearch.Application.Interfaces;
using JobSearch.Models.v1.Vacancy;
using MediatR;

namespace JobSearch.Application.Features.Vacancy.Query
{
    public class GetAllVacancyQueryHandler : IRequestHandler<GetAllVacancyQuery, List<GetVacancyDto>>
    {
        private readonly IVacancyService _vacancyService;

        public GetAllVacancyQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<List<GetVacancyDto>> Handle(GetAllVacancyQuery request, CancellationToken cancellationToken)
       => await _vacancyService.GetAll(request.Model);


    }
}
