using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Seniority;
using MediatR;

namespace JobSearch.Application.Features.Seniority.Command
{
    public class CreateSeniorityCommandHandler : IRequestHandler<CreateSeniorityCommand, ApiResult<CreateSeniorityResponse>>
    {
        private readonly ISeniorityService _service;

        public CreateSeniorityCommandHandler(ISeniorityService service)
        {
            _service = service;
        }

        public async Task<ApiResult<CreateSeniorityResponse>> Handle(CreateSeniorityCommand request, CancellationToken cancellationToken)
        => await _service.Add(request.SeniorityRequest);
    }
}
