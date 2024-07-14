using JobSearch.Application.Result;
using JobSearch.Models.v1.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Application.Interfaces
{
    public interface ISalaryService
    {
        Task<ApiResult<CreateSalaryResponse>> Add(SalaryRequest request);
    }
}
