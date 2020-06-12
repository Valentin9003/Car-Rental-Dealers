﻿using Domain.Models.CarAds;
using Application.Mapping;

namespace Application.Features.CarAds.Queries.Categories
{
    public class GetCarAdCategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int TotalCarAds { get; set; }
    }
}
