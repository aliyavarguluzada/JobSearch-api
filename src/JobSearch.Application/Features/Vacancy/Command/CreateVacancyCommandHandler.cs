using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Vacancy;
using MediatR;

namespace JobSearch.Application.CQRS.Vacancies.Command
{
    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand, ApiResult<CreateVacancyResponse>>
    {
        private readonly IVacancyService _vacancyService;
        public CreateVacancyCommandHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }
        public async Task<ApiResult<CreateVacancyResponse>> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        => await _vacancyService.Add(request.VacancyRequest);

    }
}
