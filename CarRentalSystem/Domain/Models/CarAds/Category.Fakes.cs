using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.CarAds
{
    class CategoryFakes
    {
        public const string ValidCategoryName = "Economy";

        public class CategoryDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Category);

            public object? Create(Type type)
                => new Category(ValidCategoryName, "Valid description text");

            public Priority Priority => Priority.Default;
        }
    }
}
