using System.Threading;
using System.Threading.Tasks;
using Application.Features.CarAds;
using Application.Features.CarAds.Queries.Common;
using Application.Features.CarAds.Queries.Search;
using MediatR;

namespace Application.Features.CarAds.Queries.Search
{
    public class SearchCarAdsQuery : CarAdsQuery, IRequest<SearchCarAdsOutputModel>
    {
        public class SearchCarAdsQueryHandler : CarAdsQueryHandler, IRequestHandler<
            SearchCarAdsQuery, 
            SearchCarAdsOutputModel>
        {
            public SearchCarAdsQueryHandler(ICarAdRepository carAdRepository)
                : base(carAdRepository)
            {
            }

            public async Task<SearchCarAdsOutputModel> Handle(
                SearchCarAdsQuery request,
                CancellationToken cancellationToken)
            {
                var carAdListings = await base.GetCarAdListings<CarAdOutputModel>(
                    request,
                    cancellationToken: cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    cancellationToken: cancellationToken);

                return new SearchCarAdsOutputModel(carAdListings, request.Page, totalPages);
            }
        }
    }
}
