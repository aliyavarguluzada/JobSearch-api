using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Currency;

namespace JobSearch.Infrastructure.Services
{
    public class CurrencyService : BaseService, ICurrencyService
    {
        public CurrencyService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


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

                await _unitOfWork.CurrenciesWrite.Table.AddAsync(currency);
                await _unitOfWork.CurrenciesWrite.Complete();

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
