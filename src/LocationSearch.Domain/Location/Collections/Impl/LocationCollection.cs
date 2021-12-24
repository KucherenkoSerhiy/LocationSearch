using System.Collections.Generic;
using System.Linq;
using Core.Patterns;
using LocationSearch.Domain.Location.Specification.SpecificationParameterModels;

namespace LocationSearch.Domain.Location.Collections.Impl
{
    public class LocationCollection : ILocationCollection
    {
        public SortedList<double, Models.Location> Values { get; }
        private readonly IEnumerable<ISpecification<Models.Location, LocationSpecificationParameters>> _specifications;

        public LocationCollection(
            IEnumerable<ISpecification<Models.Location, LocationSpecificationParameters>> specifications)
        {
            _specifications = specifications;

            Values = new SortedList<double, Models.Location>();
        }

        public void Add(Models.Location value, Models.Location referenceLocation, double thresholdDistance, int maxNumberOfValues)
        {
            var parameters = new LocationSpecificationParameters
            {
                ReferenceLocation = referenceLocation,
                ThresholdDistance = thresholdDistance
            };
            if (_specifications.All(s => s.IsSatisfiedBy(value, parameters)))
            {
                var distance = value.CalculateDistance(referenceLocation);
                
                Values.Add(distance, value);
                if (Values.Count > maxNumberOfValues)
                    Values.RemoveAt(Values.Count-1);
            }
                
        }
    }
}