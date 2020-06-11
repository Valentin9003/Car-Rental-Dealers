﻿using Domain.Common;
using Domain.Exceptions;

using static Domain.Models.ModelConstants.Common;
using static Domain.Models.ModelConstants.Category;

namespace Domain.Models.CarAds
{
    public class Category: Entity<int>
    {
        internal Category(string name, string description)
        {
            this.Validate(name, description);

            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }

        public string Description { get; }

        private void Validate(string name, string description)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidCarAdException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
