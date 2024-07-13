using JobSearch.Application.Result;
using JobSearch.Models.v1.JobType;
using MediatR;

namespace JobSearch.Application.Features.JobType.Command
{
    public class CreateJobTypeCommand : IRequest<ApiResult<CreateJobTypeResponse>>
    {
        public CreateJobTypeCommand(JobTypeRequest request)
        {
            JobTypeRequest = request;
        }
        public JobTypeRequest JobTypeRequest { get; set; }
    }
}
