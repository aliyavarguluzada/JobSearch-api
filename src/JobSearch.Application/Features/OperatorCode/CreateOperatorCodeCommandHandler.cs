using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.OperatorCode;
using MediatR;

namespace JobSearch.Application.Features.OperatorCode
{
    public class CreateOperatorCodeCommandHandler : IRequestHandler<CreateOperatorCodeCommand, ApiResult<CreateOperatorCodeResponse>>
    {
        private readonly IOperatorCodeService _operatorCodeService;

        public CreateOperatorCodeCommandHandler(IOperatorCodeService operatorCodeService)
        {
            _operatorCodeService = operatorCodeService;
        }

        public async Task<ApiResult<CreateOperatorCodeResponse>> Handle(CreateOperatorCodeCommand request, CancellationToken cancellationToken)
        => await _operatorCodeService.Add(request.OperatorCodeRequest);
    }
}
