using Application.Features.CarAds.Queries.Common;
using System.Collections.Generic;

namespace Application.Features.CarAds.Queries.Mine
{
    public class MineCarAdsOutputModel : CarAdsOutputModel<MineCarAdOutputModel>
    {
        public MineCarAdsOutputModel(
            IEnumerable<MineCarAdOutputModel> carAds, 
            int page, 
            int totalPages) 
            : base(carAds, page, totalPages)
        {
        }
    }
}
