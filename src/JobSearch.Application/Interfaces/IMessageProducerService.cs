using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Application.Interfaces
{
    public interface IMessageProducerService
    {
        Task PublishAsync<T>(T message, string queueName);
        Task SubscribeAsync<T>(string queueName, Action<T> onMessage);
    }
}
