using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Currency;

namespace JobSearch.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<CreateCurrencyResponse>> Add(CurrencyRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateCurrencyResponse>.Error();


                var currency = new JobSearch.Domain.Entities.Currency()
                {
                    Name = request.Name,
                    Symbol = request.Symbol
                };

                var response = new CreateCurrencyResponse() { Name = currency.Name, Symbol = request.Symbol };

                await _unitOfWork.Currencies.Table.AddAsync(currency);
                await _unitOfWork.Currencies.Complete();

                return ApiResult<CreateCurrencyResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateCurrencyResponse>.Error();
            }
        }
    }
}
