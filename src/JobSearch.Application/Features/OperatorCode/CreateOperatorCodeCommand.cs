using JobSearch.Application.Result;
using JobSearch.Models.v1.OperatorCode;
using MediatR;

namespace JobSearch.Application.Features.OperatorCode
{
    public class CreateOperatorCodeCommand : IRequest<ApiResult<CreateOperatorCodeResponse>>
    {
        public CreateOperatorCodeCommand(OperatorCodeRequest request)
        {
            OperatorCodeRequest = request;
        }
        public OperatorCodeRequest OperatorCodeRequest { get; set; }
    }
}
