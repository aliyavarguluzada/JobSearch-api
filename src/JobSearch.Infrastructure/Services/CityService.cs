﻿using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.City;

namespace JobSearch.Infrastructure.Services
{
    public class CityService : BaseService, ICityService
    {
        public CityService(IUnitOfWork unitOfWork,IMessageProducerService messageProducerService) : base(unitOfWork,messageProducerService) { }


        public async Task<ApiResult<CreateCityResponse>> Add(CityRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateCityResponse>.Error();


                var city = new JobSearch.Domain.Entities.City() { Name = request.Name };

                var response = new CreateCityResponse() { Name = city.Name };

                await _unitOfWork.CitiesWrite.Table.AddAsync(city);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.CitiesWrite.Complete();


                return ApiResult<CreateCityResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateCityResponse>.Error();
            }
        }
    }
}
