using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Address;

namespace JobSearch.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<ApiResult<CreateAddressResponse>> Add(AddressRequest request)
        {

            try
            {
                if (string.IsNullOrEmpty(request.Address))
                    return ApiResult<CreateAddressResponse>.Error();


                var address = new JobSearch.Domain.Entities.Address()
                {
                    Name = request.Address,
                    CityId = request.CityId,
                    Street = request.Street
                };

                var response = new CreateAddressResponse()
                {
                    Address = request.Address,
                    CityId = request.CityId,
                    Street = request.Street
                };

                await _unitOfWork.Addresses.Table.AddAsync(address);
                await _unitOfWork.Addresses.Complete();

                return ApiResult<CreateAddressResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateAddressResponse>.Error();
            }
        }
    }
}
