using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;

namespace JobSearch.Infrastructure.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IMessageProducerService messageProducerService) : base(unitOfWork, messageProducerService) { }


        public async Task<ApiResult<CreateCategoryResponse>> Add(CategoryRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateCategoryResponse>.Error();


                var category = new JobSearch.Domain.Entities.Category() { Name = request.Name };

                var response = new CreateCategoryResponse() { Name = category.Name };

                await _unitOfWork.CategoriesWrite.Table.AddAsync(category);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.CategoriesWrite.Complete();

                return ApiResult<CreateCategoryResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateCategoryResponse>.Error();
            }
        }
    }
}

