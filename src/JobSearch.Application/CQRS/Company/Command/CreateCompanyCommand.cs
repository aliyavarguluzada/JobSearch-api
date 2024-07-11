using JobSearch.Application.Result;
using JobSearch.Domain.Entities;
using JobSearch.Models.v1.Company;
using MediatR;

namespace JobSearch.Application.CQRS.Company.Command
{
    public class CreateCompanyCommand : IRequest<ApiResult<CreateCompanyResponse>>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? About { get; set; }
    }
}
