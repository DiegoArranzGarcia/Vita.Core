using System;

namespace Vita.Core.Domain.Events
{
    public abstract class IntegrationEvent
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public string Type { get; private set; }
        public DateTimeOffset OcurredAt { get; private set; }

        protected IntegrationEvent(int version, string type)
        {
            Id = Guid.NewGuid();
            Version = version;
            Type = type;
            OcurredAt = DateTimeOffset.Now;
        }
    }
}
