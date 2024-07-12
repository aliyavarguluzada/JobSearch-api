using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Seniority;

namespace JobSearch.Infrastructure.Services
{
    public class SeniorityService : ISeniorityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SeniorityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResult<CreateSeniorityResponse>> Add(SeniorityRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateSeniorityResponse>.Error();


                var seniority = new JobSearch.Domain.Entities.Seniority() { Name = request.Name };

                var response = new CreateSeniorityResponse() { Name = seniority.Name };

                _unitOfWork.Seniorities.Add(seniority);

                return ApiResult<CreateSeniorityResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateSeniorityResponse>.Error();
            }
        }
    }
}
