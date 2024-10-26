using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;

namespace JobSearch.Infrastructure.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMessageProducerService _messageProducerService;

        public BaseService(IUnitOfWork unitOfWork, IMessageProducerService messageProducerService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _messageProducerService = messageProducerService ?? throw new ArgumentNullException(nameof(messageProducerService));
        }

    }
}
