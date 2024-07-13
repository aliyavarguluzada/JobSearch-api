using JobSearch.Application.Result;
using JobSearch.Models.v1.City;
using JobSearch.Models.v1.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Application.Interfaces
{
    public interface ICurrencyService
    {
        Task<ApiResult<CreateCurrencyResponse>> Add(CurrencyRequest request);
    }
}
