using JobSearch.Application.Result;
using JobSearch.Models.v1.Seniority;
using MediatR;

namespace JobSearch.Application.CQRS.Seniority.Command
{
    public class CreateSeniorityCommand : IRequest<ApiResult<CreateSeniorityResponse>>
    {
        public CreateSeniorityCommand(SeniorityRequest request)
        {
            SeniorityRequest = request;
        }

        public SeniorityRequest SeniorityRequest { get; set; }
    }
}
