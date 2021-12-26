using Azure.Messaging.ServiceBus;
using System;
using System.Threading.Tasks;
using Vita.Core.Domain.Events;

namespace Vita.Core.Infrastructure.AzureServiceBus
{
    public class IntegrationEventPublisher : IIntegrationEventPublisher
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;

        public IntegrationEventPublisher(string connectionString, string queueName)
        {
            _client = new ServiceBusClient(connectionString);
            _sender = _client.CreateSender(queueName);
        }
        
        public async Task PublishAsync(IntegrationEvent integrationEvent)
        {
            try
            {
                var serviceBusMessage = new ServiceBusMessage
                {
                    Body = new BinaryData(integrationEvent),
                };

                await _sender.SendMessageAsync(serviceBusMessage);
            }
            finally
            {
                await _sender.DisposeAsync();
                await _client.DisposeAsync();
            }
        }
    }
}
