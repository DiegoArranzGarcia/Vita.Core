using System;
using System.Collections.Generic;
using Vita.Core.Domain.Events;

namespace Vita.Core.Domain.Repositories
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public List<DomainEvent> Events { get; set; } = new();

        public bool IsTransient()
        {
            return Id == Guid.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Entity)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
                return false;

            return item.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ 31;
        }
    }
}
