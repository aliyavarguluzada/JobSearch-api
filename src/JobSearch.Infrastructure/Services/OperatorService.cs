using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Operator;

namespace JobSearch.Infrastructure.Services
{
    public class OperatorService : IOperatorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OperatorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<CreateOperatorResponse>> Add(OperatorRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateOperatorResponse>.Error();


                var @operator = new JobSearch.Domain.Entities.Operator()
                {
                    Name = request.Name,
                };

                var response = new CreateOperatorResponse() { Name = @operator.Name };

                await _unitOfWork.Operators.Table.AddAsync(@operator);
                await _unitOfWork.Operators.Complete();


                return ApiResult<CreateOperatorResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateOperatorResponse>.Error();
            }
        }
    }
}
