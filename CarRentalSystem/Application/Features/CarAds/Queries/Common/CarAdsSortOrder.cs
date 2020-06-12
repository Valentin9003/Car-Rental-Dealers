﻿using System;
using System.Linq.Expressions;
using Domain.Models.CarAds;
using Application.Common;

namespace Application.Features.CarAds.Queries.Common
{
    public class CarAdsSortOrder : SortOrder<CarAd>
    {
        public CarAdsSortOrder(string? sortBy, string? order)
            : base(sortBy, order)
        {
        }

        public override Expression<Func<CarAd, object>> ToExpression()
            => this.SortBy switch
            {
                "price" => carAd => carAd.PricePerDay,
                "manufacturer" => carAd => carAd.Manufacturer.Name,
                _ => carAd => carAd.Id
            };
    }
}
