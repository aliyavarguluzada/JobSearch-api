using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Currency;
using MediatR;

namespace JobSearch.Application.Features.Currency.Command
{
    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, ApiResult<CreateCurrencyResponse>>
    {
        private readonly ICurrencyService _currencyService;

        public CreateCurrencyCommandHandler(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<ApiResult<CreateCurrencyResponse>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        => await _currencyService.Add(request.CurrencyRequest);
    }
}
