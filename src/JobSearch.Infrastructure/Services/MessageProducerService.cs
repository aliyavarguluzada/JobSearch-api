using JobSearch.Application.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace JobSearch.Infrastructure.Services
{
    public class MessageProducerService : IMessageProducerService
    {

        private readonly Task<IConnection> _connectionTask;
        private readonly Task<IModel> _channelTask;

        public MessageProducerService()
        {
            _connectionTask = CreateConnectionAsync();
            _channelTask = _connectionTask.ContinueWith(t => CreateChannelAsync(t.Result)).Unwrap();
        }

        private async Task<IConnection> CreateConnectionAsync()
        {
            var factory = new ConnectionFactory
            { HostName = "localhost", Password = "password", UserName = "user", VirtualHost = "/" };

            return await Task.Run(() => factory.CreateConnection());
        }

        private async Task<IModel> CreateChannelAsync(IConnection connection)
        {
            return await Task.Run(() => connection.CreateModel());
        }

        public async Task PublishAsync<T>(T message, string queueName)
        {
            var channel = await _channelTask;
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }

        public async Task SubscribeAsync<T>(string queueName, Action<T> onMessage)
        {
            var channel = await _channelTask;
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(body));
                onMessage(message);
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }

    }
}
