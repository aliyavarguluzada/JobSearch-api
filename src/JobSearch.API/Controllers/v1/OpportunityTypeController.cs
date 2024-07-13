using JobSearch.Application.CQRS.OpportunityType;
using JobSearch.Application.Result;
using JobSearch.Models.v1.OpportunityType;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/opportunityTypes")]
    [ApiController]
    public class OpportunityTypeController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateOpportunityTypeResponse>> Add(OpportunityTypeRequest request) =>
            await Mediator.Send(new CreateOpportunityTypeCommand(request));
    }
}
