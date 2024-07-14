using JobSearch.Application.Result;
using JobSearch.Models.v1.Address;

namespace JobSearch.Application.Interfaces
{
    public interface IAddressService
    {
        Task<ApiResult<CreateAddressResponse>> Add(AddressRequest request);
    }
}
