using JobSearch.Application.Result;
using JobSearch.Models.v1.Salary;
using MediatR;

namespace JobSearch.Application.Features.Salary
{
    public class CreateSalaryCommand : IRequest<ApiResult<CreateSalaryResponse>>
    {
        public CreateSalaryCommand(SalaryRequest request)
        {
            SalaryRequest = request;
        }
        public SalaryRequest SalaryRequest { get; set; }
    }
}
