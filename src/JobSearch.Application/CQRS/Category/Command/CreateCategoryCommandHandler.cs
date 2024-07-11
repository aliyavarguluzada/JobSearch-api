using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;
using MediatR;

namespace JobSearch.Application.CQRS.Category.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResult<CreateCategoryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new JobSearch.Domain.Entities.Category() { Name = request.Name };

            var response = new CreateCategoryResponse() { Name = request.Name };

            _unitOfWork.Categories.Add(category);

            return ApiResult<CreateCategoryResponse>.Ok(response);
        }
    }
}
