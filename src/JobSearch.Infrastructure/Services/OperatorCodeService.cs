using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.OperatorCode;

namespace JobSearch.Infrastructure.Services
{
    public class OperatorCodeService : BaseService, IOperatorCodeService
    {
        public OperatorCodeService(IUnitOfWork unitOfWork, IMessageProducerService messageProducerService) : base(unitOfWork, messageProducerService) { }


        public async Task<ApiResult<CreateOperatorCodeResponse>> Add(OperatorCodeRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Code)
                    ||
                    request.OperatorId is 0)
                    return ApiResult<CreateOperatorCodeResponse>.Error();


                var opCode = new JobSearch.Domain.Entities.OperatorCode()
                {
                    Code = request.Code,
                    OperatorId = request.OperatorId
                };

                var response = new CreateOperatorCodeResponse() { Code = request.Code };

                await _unitOfWork.OperatorCodesWrite.Table.AddAsync(opCode);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.OperatorCodesWrite.Complete();

                return ApiResult<CreateOperatorCodeResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateOperatorCodeResponse>.Error();
            }
        }
    }
}
