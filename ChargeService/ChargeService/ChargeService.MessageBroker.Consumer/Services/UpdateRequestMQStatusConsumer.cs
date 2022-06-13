using ChargeService.BLL.Services.Interfaces;
using ChargeService.MessageBroker.Entities;
using ChargeService.MessageBroker.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ChargeService.MessageBroker.Consumer.Services
{
    public class UpdateRequestMQStatusConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly RabbitMQSettings _rabbitMQSettings;
        private readonly ILogger<UpdateRequestMQStatusConsumer> _logger;
        private readonly IServiceProvider _serviceProvider;

        public UpdateRequestMQStatusConsumer(IOptions<RabbitMQSettings> rabbitMQSettings,
            IServiceProvider serviceProvider, ILogger<UpdateRequestMQStatusConsumer> logger)
        {
            _logger = logger;

            try
            {
                _serviceProvider = serviceProvider;
                _rabbitMQSettings = rabbitMQSettings.Value;
                var factory = new ConnectionFactory
                {
                    HostName = _rabbitMQSettings.Hostname,
                    UserName = _rabbitMQSettings.UserName,
                    Password = _rabbitMQSettings.Password,
                    VirtualHost = _rabbitMQSettings.VirtualHost
                };
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.QueueDeclare(
                    queue: _rabbitMQSettings.UpdateRequestMQ,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"UpdateRequestMQStatusConsumer ctor Error");
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

                try
                {
                    var updateRequest = JsonConvert.DeserializeObject<UpdateRequestMQStatus>(content);

                    using (IServiceScope scope = _serviceProvider.CreateScope())
                    {
                        ISessionService sessionService = scope.ServiceProvider.GetRequiredService<ISessionService>();
                        await sessionService.UpdateStatusAsync(updateRequest.RequestId, updateRequest.Status);
                    }

                    _channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"UpdateRequestMQStatusConsumer Received Error");
                } 
            };
            try
            {
                _channel.BasicConsume(_rabbitMQSettings.UpdateRequestMQ, false, consumer);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"UpdateRequestMQStatusConsumer BasicConsume Error");
            }
            

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
