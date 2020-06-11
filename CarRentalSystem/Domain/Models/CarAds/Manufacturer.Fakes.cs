﻿using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.CarAds
{
    public class ManufacturerFakes
    {
        public class ManufacturerDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Manufacturer);

            public object? Create(Type type)
                => new Manufacturer("Valid manufacturer");

            public Priority Priority => Priority.Default;
        }
    }
}
