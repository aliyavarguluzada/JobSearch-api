using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Company;

namespace JobSearch.Infrastructure.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        public async Task<ApiResult<CreateCompanyResponse>> Add(CompanyRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Name)
                    ||
                    string.IsNullOrEmpty(request.Email)
                    ||
                    string.IsNullOrEmpty(request.About))
                    return ApiResult<CreateCompanyResponse>.Error();


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

                await _unitOfWork.CompaniesWrite.Table.AddAsync(company);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.CompaniesWrite.Complete();


                return ApiResult<CreateCompanyResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateCompanyResponse>.Error();
            }
        }
    }
}
