using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Operator;
using MediatR;

namespace JobSearch.Application.Features.Operator.Command
{
    public class CreateOperatorCommandHandler : IRequestHandler<CreateOperatorCommand, ApiResult<CreateOperatorResponse>>
    {
        private readonly IOperatorService _operatorService;

        public CreateOperatorCommandHandler(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        public async Task<ApiResult<CreateOperatorResponse>> Handle(CreateOperatorCommand request, CancellationToken cancellationToken)
        => await _operatorService.Add(request.OperatorRequest);
    }
}
