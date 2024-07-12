using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.JobType;

namespace JobSearch.Infrastructure.Services
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResult<CreateJobTypeResponse>> Add(JobTypeRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateJobTypeResponse>.Error();


                var jobType = new JobSearch.Domain.Entities.JobType() { Name = request.Name };

                var response = new CreateJobTypeResponse() { Name = jobType.Name };

                _unitOfWork.JobTypes.Add(jobType);

                return ApiResult<CreateJobTypeResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateJobTypeResponse>.Error();
            }
        }
    }
}
