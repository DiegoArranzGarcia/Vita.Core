namespace Vita.Core.Domain.Repositories
{
    public interface IRepository<TEntity> : IAggregateRoot where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
