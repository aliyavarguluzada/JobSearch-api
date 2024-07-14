using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Phone;

namespace JobSearch.Infrastructure.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhoneService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<CreatePhoneResponse>> Add(PhoneRequest request)
        {
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

                await _unitOfWork.Phones.Table.AddAsync(phone);
                await _unitOfWork.Phones.Complete();


                return ApiResult<CreatePhoneResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreatePhoneResponse>.Error();
            };
        }
    }
}
