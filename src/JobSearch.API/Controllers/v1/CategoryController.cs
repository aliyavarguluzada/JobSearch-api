using JobSearch.Application.Features.Category.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers.v1
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : BaseController
    {

        [HttpPost("add")]
        public async Task<ApiResult<CreateCategoryResponse>> Add([FromForm] CategoryRequest request) =>
            await Mediator.Send(new CreateCategoryCommand(request));
    }
}
