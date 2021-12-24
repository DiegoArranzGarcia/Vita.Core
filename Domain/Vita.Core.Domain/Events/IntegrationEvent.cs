using System;

namespace Vita.Core.Domain.Events
{
    internal class IntegrationEvent
    {
        public Guid Id { get; set; }
        public DateTimeOffset OcurredAt { get; set; }
        public string Type { get; set; }
    }
}
