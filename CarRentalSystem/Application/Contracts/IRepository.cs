using Domain.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IRepository<in TEntity>
      where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
