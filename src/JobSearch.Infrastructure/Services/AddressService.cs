using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Address;

namespace JobSearch.Infrastructure.Services
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork, IMessageProducerService messageProducerService) : base(unitOfWork, messageProducerService) { }

        public async Task<ApiResult<CreateAddressResponse>> Add(AddressRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrEmpty(request.Address))
                    return ApiResult<CreateAddressResponse>.Error();

                var address = new JobSearch.Domain.Entities.Address()
                {
                    Name = request.Address,
                    CityId = request.CityId,
                    Street = request.Street
                };

                var response = new CreateAddressResponse()
                {
                    Address = request.Address,
                    CityId = request.CityId,
                    Street = request.Street
                };

                // Save address to database in this transaction
                await _unitOfWork.AddressesWrite.Table.AddAsync(address);
                await _unitOfWork.AddressesWrite.Complete();
                await _unitOfWork.CommitTransactionAsync();

                // Publish the message to RabbitMQ for further processing
                await _messageProducerService.PublishAsync("addressQueue", address.ToString());

                return ApiResult<CreateAddressResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateAddressResponse>.Error();
            }
        }

    }
}

