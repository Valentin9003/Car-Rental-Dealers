using Application.Features.CarAds.Queries.Common;
using AutoMapper;
using Domain.Models.CarAds;

namespace Application.Features.CarAds.Queries.Mine
{
    public class MineCarAdOutputModel : CarAdOutputModel
    {
        public bool IsAvailable { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarAd, MineCarAdOutputModel>()
                .IncludeBase<CarAd, CarAdOutputModel>();
    }
}
