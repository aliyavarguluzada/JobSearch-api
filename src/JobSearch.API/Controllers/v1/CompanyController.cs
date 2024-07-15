using JobSearch.Application.Features.Company.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Company;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : BaseController
    {
        [HttpPost("add")]
        public async Task<ApiResult<CreateCompanyResponse>> Add([FromForm] CompanyRequest request) => 
            await Mediator.Send(new CreateCompanyCommand(request));
    }
}
