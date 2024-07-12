using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.City;

namespace JobSearch.Infrastructure.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<CreateCityResponse>> Add(CityRequest request)
        {

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateCityResponse>.Error();


                var city = new JobSearch.Domain.Entities.City() { Name = request.Name };

                var response = new CreateCityResponse() { Name = city.Name };

                _unitOfWork.Cities.Add(city);

                return ApiResult<CreateCityResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateCityResponse>.Error();
            }
        }
    }
}
