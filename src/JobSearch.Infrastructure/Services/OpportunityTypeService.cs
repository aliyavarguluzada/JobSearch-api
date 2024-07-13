using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.OpportunityType;

namespace JobSearch.Infrastructure.Services
{
    public class OpportunityTypeService : IOpportunityTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OpportunityTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResult<CreateOpportunityTypeResponse>> Add(OpportunityTypeRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateOpportunityTypeResponse>.Error();


                var opportunityType = new JobSearch.Domain.Entities.OpportunityType() { Name = request.Name };

                var response = new CreateOpportunityTypeResponse() { Name = opportunityType.Name };

                _unitOfWork.OpportunityTypes.Add(opportunityType);

                return ApiResult<CreateOpportunityTypeResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateOpportunityTypeResponse>.Error();
            }
        }
    }
}
