using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Phone;
using MediatR;

namespace JobSearch.Application.Features.Phone
{
    public class CreatePhoneCommandHandler : IRequestHandler<CreatePhoneCommand, ApiResult<CreatePhoneResponse>>
    {
        private readonly IPhoneService _phoneService;
        public CreatePhoneCommandHandler(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        public async Task<ApiResult<CreatePhoneResponse>> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
        => await _phoneService.Add(request.PhoneRequest);
    }
}
