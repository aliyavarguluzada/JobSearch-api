using JobSearch.Application.Result;
using JobSearch.Models.v1.Vacancy;
using MediatR;

namespace JobSearch.Application.CQRS.Vacancies.Command
{
    public class CreateVacancyCommand : IRequest<ApiResult<CreateVacancyResponse>>
    {
        public CreateVacancyCommand(VacancyRequest request)
        {
            VacancyRequest = request;
        }
        public VacancyRequest VacancyRequest { get; set; }
    }
}
