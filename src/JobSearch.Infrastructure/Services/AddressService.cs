using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Address;

namespace JobSearch.Infrastructure.Services
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

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

                await _unitOfWork.AddressesWrite.Table.AddAsync(address);
                await _unitOfWork.AddressesWrite.Complete();

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
