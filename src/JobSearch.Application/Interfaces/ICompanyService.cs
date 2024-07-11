using JobSearch.Application.CQRS.Category.Command;
using JobSearch.Application.CQRS.Company.Command;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<ApiResult<CreateCompanyResponse>> Add(CompanyRequest request);
    }
}
