using JobSearch.Application.Result;
using JobSearch.Models.v1.Currency;
using MediatR;

namespace JobSearch.Application.Features.Currency.Command
{
    public class CreateCurrencyCommand : IRequest<ApiResult<CreateCurrencyResponse>>
    {
        public CreateCurrencyCommand(CurrencyRequest request)
        {
            CurrencyRequest = request;
        }
        public CurrencyRequest CurrencyRequest { get; set; }
    }
}
