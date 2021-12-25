using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vita.Core.Domain.Repositories;

namespace Vita.Core.Infrastructure.Sql
{
    public abstract class VitaDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public VitaDbContext(DbContextOptions<VitaDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var entitiesWithEvents = ChangeTracker.Entries()
                                                  .Select(e => e.Entity as Entity)
                                                  .Where(e => e != null && e.Events.Any())
                                                  .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();

                entity.Events.Clear();

                foreach (var domainEvent in events)
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }

            return result;
        }
    }
}
