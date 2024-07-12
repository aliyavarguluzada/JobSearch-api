using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.JobType;
using MediatR;

namespace JobSearch.Application.CQRS.JobType
{
    public class CreateJobTypeCommandHandler : IRequestHandler<CreateJobTypeCommand, ApiResult<CreateJobTypeResponse>>
    {
        private readonly IJobTypeService _jobTypeService;

        public CreateJobTypeCommandHandler(IJobTypeService jobTypeService)
        {
            _jobTypeService = jobTypeService;
        }

        public async Task<ApiResult<CreateJobTypeResponse>> Handle(CreateJobTypeCommand request, CancellationToken cancellationToken)
            => await _jobTypeService.Add(request.JobTypeRequest);
    }
}
