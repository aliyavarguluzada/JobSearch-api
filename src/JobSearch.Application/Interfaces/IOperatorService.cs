using JobSearch.Application.Result;
using JobSearch.Models.v1.Operator;

namespace JobSearch.Application.Interfaces
{
    public interface IOperatorService
    {
        Task<ApiResult<CreateOperatorResponse>> Add(OperatorRequest request);
    }
}
