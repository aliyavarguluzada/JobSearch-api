using JobSearch.Application.Result;
using JobSearch.Models.v1.Address;
using MediatR;

namespace JobSearch.Application.Features.Address
{
    public class CreateAddressCommand : IRequest<ApiResult<CreateAddressResponse>>
    {

        public CreateAddressCommand(AddressRequest request)
        {
            AddressRequest = request;
        }

        public AddressRequest AddressRequest { get; set; }
    }
}
