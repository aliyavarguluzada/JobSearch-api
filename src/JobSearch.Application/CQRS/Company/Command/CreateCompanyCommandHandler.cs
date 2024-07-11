using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Company;
using MediatR;

namespace JobSearch.Application.CQRS.Company.Command
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ApiResult<CreateCompanyResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<CreateCompanyResponse>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new JobSearch.Domain.Entities.Company()
            {
                Name = request.Name,
                Email = request.Email,
                About = request.About
            };

            var response = new CreateCompanyResponse()
            {
                Email = company.Email,
                Name = company.Name,
                About = company.About
            };

            _unitOfWork.Companies.Add(company);

            return ApiResult<CreateCompanyResponse>.Ok(response);

        }


    }
}
