using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.OpportunityType;

namespace JobSearch.Infrastructure.Services
{
    public class OpportunityTypeService : BaseService, IOpportunityTypeService
    {
        public OpportunityTypeService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        public async Task<ApiResult<CreateOpportunityTypeResponse>> Add(OpportunityTypeRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateOpportunityTypeResponse>.Error();


                var opportunityType = new JobSearch.Domain.Entities.OpportunityType() { Name = request.Name };

                var response = new CreateOpportunityTypeResponse() { Name = opportunityType.Name };

                await _unitOfWork.OpportunityTypesWrite.Table.AddAsync(opportunityType);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.OpportunityTypesWrite.Complete();


                return ApiResult<CreateOpportunityTypeResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateOpportunityTypeResponse>.Error();
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }
        }
    }
}
