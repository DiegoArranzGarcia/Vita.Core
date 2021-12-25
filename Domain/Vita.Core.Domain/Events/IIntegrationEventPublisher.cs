using System.Threading.Tasks;

namespace Vita.Core.Domain.Events
{
    public interface IIntegrationEventPublisher
    {
        Task PublishAsync(IntegrationEvent integrationEvent);
    }
}
