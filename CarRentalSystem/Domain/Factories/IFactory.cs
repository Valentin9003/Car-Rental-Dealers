using Domain.Common;

namespace Domain.Factories
{
    public interface IFactory<out TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
