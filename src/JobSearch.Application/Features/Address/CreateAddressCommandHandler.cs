using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Address;
using MediatR;

namespace JobSearch.Application.Features.Address
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, ApiResult<CreateAddressResponse>>
    {
        private readonly IAddressService _addressService;

        public CreateAddressCommandHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<ApiResult<CreateAddressResponse>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        => await _addressService.Add(request.AddressRequest);
    }
}
