﻿using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Phone;

namespace JobSearch.Infrastructure.Services
{
    public class PhoneService : BaseService, IPhoneService
    {
        public PhoneService(IUnitOfWork unitOfWork, IMessageProducerService messageProducerService) : base(unitOfWork, messageProducerService) { }


        public async Task<ApiResult<CreatePhoneResponse>> Add(PhoneRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Number))
                    return ApiResult<CreatePhoneResponse>.Error();


                var phone = new JobSearch.Domain.Entities.Phone()
                {
                    Number = request.Number,
                    OperatorCodeId = request.OperatorId
                };

                var response = new CreatePhoneResponse() { Number = phone.Number };

                await _unitOfWork.PhonesWrite.Table.AddAsync(phone);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.PhonesWrite.Complete();


                return ApiResult<CreatePhoneResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreatePhoneResponse>.Error();
            }
        }
    }
}
