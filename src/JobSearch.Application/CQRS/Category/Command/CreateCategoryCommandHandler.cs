using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;
using MediatR;

namespace JobSearch.Application.CQRS.Category.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResult<CreateCategoryResponse>>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ApiResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        => await _categoryService.Add(request.CategoryRequest);
    }
}
