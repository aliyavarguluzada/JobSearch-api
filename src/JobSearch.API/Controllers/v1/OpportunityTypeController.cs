using Asp.Versioning;
using JobSearch.Application.Features.OpportunityType.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.OpportunityType;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/opportunityType-management")]
    [ApiController]
    [ApiVersion(1)]
    public class OpportunityTypeController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("opportunityTypes")]
        public async Task<ApiResult<CreateOpportunityTypeResponse>> Add([FromForm] OpportunityTypeRequest request) =>
            await Mediator.Send(new CreateOpportunityTypeCommand(request));
    }
}
