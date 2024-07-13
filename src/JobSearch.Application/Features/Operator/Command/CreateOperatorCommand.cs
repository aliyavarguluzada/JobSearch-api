using JobSearch.Application.Result;
using JobSearch.Models.v1.Operator;
using MediatR;

namespace JobSearch.Application.Features.Operator.Command
{
    public class CreateOperatorCommand : IRequest<ApiResult<CreateOperatorResponse>>
    {
        public CreateOperatorCommand(OperatorRequest request)
        {
            OperatorRequest = request;
        }
        public OperatorRequest OperatorRequest { get; set; }
    }
}
