using System.Collections.Generic;

namespace Application.Features.CarAds.Queries.Common
{
    public abstract class CarAdsOutputModel<TCarAdOutputModel>
    {
        internal CarAdsOutputModel(
            IEnumerable<TCarAdOutputModel> carAds,
            int page,
            int totalPages)
        {
            this.CarAds = carAds;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TCarAdOutputModel> CarAds { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
