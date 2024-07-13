using JobSearch.Application.Result;
using JobSearch.Models.v1.Company;

namespace JobSearch.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<ApiResult<CreateCompanyResponse>> Add(CompanyRequest request);
    }
}
