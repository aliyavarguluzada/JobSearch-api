using JobSearch.Application.Result;
using JobSearch.Models.v1.OpportunityType;

namespace JobSearch.Application.Interfaces
{
    public interface IOpportunityTypeService
    {
        Task<ApiResult<CreateOpportunityTypeResponse>> Add(OpportunityTypeRequest request);
    }
}
