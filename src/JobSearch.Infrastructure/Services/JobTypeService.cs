using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.JobType;

namespace JobSearch.Infrastructure.Services
{
    public class JobTypeService : BaseService, IJobTypeService
    {
        public JobTypeService(IUnitOfWork unitOfWork, IMessageProducerService messageProducerService) : base(unitOfWork, messageProducerService) { }


        public async Task<ApiResult<CreateJobTypeResponse>> Add(JobTypeRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateJobTypeResponse>.Error();


                var jobType = new JobSearch.Domain.Entities.JobType() { Name = request.Name };

                var response = new CreateJobTypeResponse() { Name = jobType.Name };

                await _unitOfWork.JobTypesWrite.Table.AddAsync(jobType);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.CategoriesWrite.Complete();


                return ApiResult<CreateJobTypeResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateJobTypeResponse>.Error();
            }
        }
    }
}
