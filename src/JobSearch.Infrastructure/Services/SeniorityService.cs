using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Seniority;

namespace JobSearch.Infrastructure.Services
{
    public class SeniorityService : BaseService, ISeniorityService
    {
        public SeniorityService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        public async Task<ApiResult<CreateSeniorityResponse>> Add(SeniorityRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateSeniorityResponse>.Error();


                var seniority = new JobSearch.Domain.Entities.Seniority() { Name = request.Name };

                var response = new CreateSeniorityResponse() { Name = seniority.Name };

                await _unitOfWork.SenioritiesWrite.Table.AddAsync(seniority);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SenioritiesWrite.Complete();


                return ApiResult<CreateSeniorityResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateSeniorityResponse>.Error();
            }
        }
    }
}
