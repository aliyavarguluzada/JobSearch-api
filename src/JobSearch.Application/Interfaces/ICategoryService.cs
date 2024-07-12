using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;

namespace JobSearch.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResult<CreateCategoryResponse>> Add(CategoryRequest request);

    }
}
