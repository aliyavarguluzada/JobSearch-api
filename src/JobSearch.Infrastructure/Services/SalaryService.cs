using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Salary;

namespace JobSearch.Infrastructure.Services
{
    public class SalaryService : BaseService, ISalaryService
    {
        public SalaryService(IUnitOfWork unitOfWork, IMessageProducerService messageProducerService) : base(unitOfWork, messageProducerService) { }


        public async Task<ApiResult<CreateSalaryResponse>> Add(SalaryRequest request)
        {

            await _unitOfWork.BeginTransactionAsync();
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

                await _unitOfWork.SalariesWrite.Table.AddAsync(salary);
                await _unitOfWork.SalariesWrite.Complete();
                await _unitOfWork.CommitTransactionAsync();

                return ApiResult<CreateSalaryResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateSalaryResponse>.Error();
            }
        }
    }
}

