using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.CarAds
{
   public  class OptionsFakes
    {
        public class OptionsDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Options);

            public object? Create(Type type)
                => new Options(true, 4, TransmissionType.Automatic);

            public Priority Priority => Priority.Default;
        }
    }
}
