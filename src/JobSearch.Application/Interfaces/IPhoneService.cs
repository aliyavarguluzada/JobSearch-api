using JobSearch.Application.Result;
using JobSearch.Models.v1.Phone;

namespace JobSearch.Application.Interfaces
{
    public interface IPhoneService
    {
        Task<ApiResult<CreatePhoneResponse>> Add(PhoneRequest request);
    }
}
