using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.OpportunityType;
using MediatR;

namespace JobSearch.Application.Features.OpportunityType.Command
{
    public class CreateOpportunityTypeCommandHandler : IRequestHandler<CreateOpportunityTypeCommand, ApiResult<CreateOpportunityTypeResponse>>
    {
        private readonly IOpportunityTypeService _opportunityTypeService;

        public CreateOpportunityTypeCommandHandler(IOpportunityTypeService opportunityTypeService)
        {
            _opportunityTypeService = opportunityTypeService;
        }

        public async Task<ApiResult<CreateOpportunityTypeResponse>> Handle(CreateOpportunityTypeCommand request, CancellationToken cancellationToken)
        => await _opportunityTypeService.Add(request.OpportunityTypeRequest);
    }
}
