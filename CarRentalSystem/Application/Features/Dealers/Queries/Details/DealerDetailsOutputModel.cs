using AutoMapper;
using Domain.Models.Dealers;
using Application.Features.Dealers.Queries.Common;

namespace Application.Features.Dealers.Queries.Details
{
    public class DealerDetailsOutputModel : DealerOutputModel
    {
        public int TotalCarAds { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Dealer, DealerDetailsOutputModel>()
                .IncludeBase<Dealer, DealerOutputModel>()
                .ForMember(d => d.TotalCarAds, cfg => cfg
                    .MapFrom(d => d.CarAds.Count));
    }
}
