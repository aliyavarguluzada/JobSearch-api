using JobSearch.Application.Result;
using JobSearch.Models.v1.Seniority;

namespace JobSearch.Application.Interfaces
{
    public interface ISeniorityService
    {
        Task<ApiResult<CreateSeniorityResponse>> Add(SeniorityRequest request);

    }
}
