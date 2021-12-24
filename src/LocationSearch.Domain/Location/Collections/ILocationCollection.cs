using System.Collections.Generic;

namespace LocationSearch.Domain.Location.Collections
{
    public interface ILocationCollection
    {
        List<Models.Location> Values { get; }
        void Add(Models.Location value, Models.Location referenceLocation, double thresholdDistance, int maxNumberOfValues);
    }
}