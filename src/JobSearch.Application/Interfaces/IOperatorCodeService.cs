using JobSearch.Application.Result;
using JobSearch.Models.v1.OperatorCode;

namespace JobSearch.Application.Interfaces
{
    public interface IOperatorCodeService
    {
        Task<ApiResult<CreateOperatorCodeResponse>> Add(OperatorCodeRequest request);
    }
}
