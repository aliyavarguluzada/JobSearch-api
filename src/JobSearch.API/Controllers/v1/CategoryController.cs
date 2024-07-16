using Asp.Versioning;
using JobSearch.Application.Features.Category.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/v{apiVersion}/category-management")]
    [ApiController]
    [ApiVersion(1)]
    public class CategoryController : BaseController
    {
        [MapToApiVersion(1)]
        [HttpPost("categories")]
        public async Task<ApiResult<CreateCategoryResponse>> Add([FromForm] CategoryRequest request) =>
            await Mediator.Send(new CreateCategoryCommand(request));
    }
}
