using JobSearch.Application.Result;
using JobSearch.Models.v1.Phone;
using MediatR;

namespace JobSearch.Application.Features.Phone
{
    public class CreatePhoneCommand : IRequest<ApiResult<CreatePhoneResponse>>
    {
        public CreatePhoneCommand(PhoneRequest request)
        {
            PhoneRequest = request;
        }
        public PhoneRequest PhoneRequest { get; set; }
    }
}
