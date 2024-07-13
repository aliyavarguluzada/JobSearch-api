using JobSearch.Application.Result;
using JobSearch.Models.v1.OpportunityType;
using MediatR;

namespace JobSearch.Application.Features.OpportunityType.Command
{
    public class CreateOpportunityTypeCommand : IRequest<ApiResult<CreateOpportunityTypeResponse>>
    {
        public CreateOpportunityTypeCommand(OpportunityTypeRequest request)
        {
            OpportunityTypeRequest = request;
        }
        public OpportunityTypeRequest OpportunityTypeRequest { get; set; }
    }
}
