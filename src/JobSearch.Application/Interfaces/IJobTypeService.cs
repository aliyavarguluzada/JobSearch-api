using JobSearch.Application.Result;
using JobSearch.Models.v1.JobType;

namespace JobSearch.Application.Interfaces
{
    public interface IJobTypeService
    {
        Task<ApiResult<CreateJobTypeResponse>> Add(JobTypeRequest request);
    }
}
