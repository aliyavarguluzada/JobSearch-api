using JobSearch.Application.Result;
using JobSearch.Models.v1.Category;
using JobSearch.Models.v1.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Application.Interfaces
{
    public interface ICityService
    {
        Task<ApiResult<CreateCityResponse>> Add(CityRequest request);

    }
}
