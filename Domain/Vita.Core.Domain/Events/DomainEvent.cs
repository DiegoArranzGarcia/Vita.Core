using System;

namespace Vita.Core.Domain.Events
{
    public abstract class DomainEvent
    {
        public DateTimeOffset OcurredAt { get; set; }
    }
}
