﻿using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;

namespace JobSearch.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public async Task<ApiResult<CreateCategoryResponse>> Add(CategoryRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateCategoryResponse>.Error();


                var category = new JobSearch.Domain.Entities.Category() { Name = request.Name };

                var response = new CreateCategoryResponse() { Name = category.Name };

                _unitOfWork.Categories.Add(category);

                return ApiResult<CreateCategoryResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateCategoryResponse>.Error();
            }
        }
    }
}