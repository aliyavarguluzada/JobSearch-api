using JobSearch.Application.Result;
using JobSearch.Models.v1.Vacancy;
using MediatR;

namespace JobSearch.Application.CQRS.Vacancies.Command
{
    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand, ApiResult<CreateVacancyResponse>>
    {
        public CreateVacancyCommandHandler() 
        {
        }
        public Task<ApiResult<CreateVacancyResponse>> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
