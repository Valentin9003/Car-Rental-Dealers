using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Models.Dealers;
using Application.Features.Dealers.Queries.Common;
using Application.Features.Dealers.Queries.Details;

namespace Application.Features.Dealers
{
    public interface IDealerRepository : IRepository<Dealer>
    {
        Task<Dealer> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetDealerId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasCarAd(int dealerId, int carAdId, CancellationToken cancellationToken = default);

        Task<DealerDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<DealerOutputModel> GetDetailsByCarId(int carAdId, CancellationToken cancellationToken = default);
    }
}
