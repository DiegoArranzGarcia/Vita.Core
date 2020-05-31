using System;
using System.Threading;
using System.Threading.Tasks;

namespace Vita.Core.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
