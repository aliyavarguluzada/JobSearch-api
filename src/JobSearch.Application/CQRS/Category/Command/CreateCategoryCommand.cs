using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;
using MediatR;

namespace JobSearch.Application.CQRS.Category.Command
{
    public class CreateCategoryCommand : IRequest<ApiResult<CreateCategoryResponse>>
    {
        public string Name { get; set; }
    }
}
