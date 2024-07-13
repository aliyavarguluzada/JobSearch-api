using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Company;
using MediatR;

namespace JobSearch.Application.Features.Company.Command
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ApiResult<CreateCompanyResponse>>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<ApiResult<CreateCompanyResponse>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            => await _companyService.Add(request.CompanyRequest);





    }
}
