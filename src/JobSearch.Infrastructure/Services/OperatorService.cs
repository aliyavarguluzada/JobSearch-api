using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Operator;

namespace JobSearch.Infrastructure.Services
{
    public class OperatorService : BaseService, IOperatorService
    {
        public OperatorService(IUnitOfWork unitOfWork, IMessageProducerService messageProducerService) : base(unitOfWork, messageProducerService) { }


        public async Task<ApiResult<CreateOperatorResponse>> Add(OperatorRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateOperatorResponse>.Error();


                var @operator = new JobSearch.Domain.Entities.Operator()
                {
                    Name = request.Name,
                };

                var response = new CreateOperatorResponse() { Name = @operator.Name };

                await _unitOfWork.OperatorsWrite.Table.AddAsync(@operator);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.OperatorsWrite.Complete();


                return ApiResult<CreateOperatorResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateOperatorResponse>.Error();
            }
        }
    }
}
