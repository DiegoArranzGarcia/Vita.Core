using System;

namespace Vita.Core.Domain.Events
{
    public abstract class DomainEvent
    {
        public DateTimeOffset OcurredAt { get; private set; }

        protected DomainEvent()
        {
            OcurredAt = DateTimeOffset.UtcNow;
        }
    }
}
