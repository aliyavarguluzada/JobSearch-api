using JobSearch.Application.CQRS.Category.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : BaseController
    {

        [HttpPost("add")]
        public async Task<ApiResult<CreateCategoryResponse>> Add(CreateCategoryCommand command) => await Mediator.Send(command);
    }
}
