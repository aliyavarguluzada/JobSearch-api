using JobSearch.Application.Result;
using JobSearch.Models.v1.Company;
using MediatR;

namespace JobSearch.Application.Features.Company.Command
{
    public class CreateCompanyCommand : IRequest<ApiResult<CreateCompanyResponse>>
    {
        public CreateCompanyCommand(CompanyRequest request)
        {
            CompanyRequest = request;
        }
        public CompanyRequest CompanyRequest { get; set; }

    }
}
