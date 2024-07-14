using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Salary;

namespace JobSearch.Infrastructure.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalaryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<CreateSalaryResponse>> Add(SalaryRequest request)
        {

            try
            {
                if (string.IsNullOrEmpty(request.Value)
                    ||
                    request.CurrencyId == 0)
                    return ApiResult<CreateSalaryResponse>.Error();


                var salary = new JobSearch.Domain.Entities.Salary()
                {
                    Value = request.Value,
                    CurrencyId = request.CurrencyId
                };

                var response = new CreateSalaryResponse() { Value = request.Value };

                await _unitOfWork.Salaries.Table.AddAsync(salary);
                await _unitOfWork.Salaries.Complete();

                return ApiResult<CreateSalaryResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateSalaryResponse>.Error();
            }
        }
    }
}
