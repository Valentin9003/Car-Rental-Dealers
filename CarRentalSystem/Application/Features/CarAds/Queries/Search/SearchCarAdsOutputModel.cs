using Application.Features.CarAds.Queries.Common;
using System.Collections.Generic;

namespace Application.Features.CarAds.Queries.Search
{
    public class SearchCarAdsOutputModel : CarAdsOutputModel<CarAdOutputModel>
    {
        public SearchCarAdsOutputModel(
            IEnumerable<CarAdOutputModel> carAds, 
            int page, 
            int totalPages) 
            : base(carAds, page, totalPages)
        {
        }
    }
}
