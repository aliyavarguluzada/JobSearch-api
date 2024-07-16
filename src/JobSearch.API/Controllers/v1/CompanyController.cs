using Asp.Versioning;
using JobSearch.Application.Features.Company.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Company;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/company-management")]
    [ApiController]
    [ApiVersion(1)]
    public class CompanyController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("companies")]
        public async Task<ApiResult<CreateCompanyResponse>> Add([FromForm] CompanyRequest request) => 
            await Mediator.Send(new CreateCompanyCommand(request));
    }
}
