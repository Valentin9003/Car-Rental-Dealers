using System;
using System.Collections.Generic;

namespace Domain.Common
{
    public interface IInitialData
    {
        Type EntityType { get; }

        IEnumerable<object> GetData();
    }
}
