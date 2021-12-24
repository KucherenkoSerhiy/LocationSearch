using System.Collections.Generic;
using System.Linq;
using Core.Patterns;
using LocationSearch.Domain.Location.Specification.SpecificationParameterModels;

namespace LocationSearch.Domain.Location.Collections.Impl
{
    public class LocationCollection : ILocationCollection
    {
        public List<Models.Location> Values { get; }
        private readonly IEnumerable<ISpecification<Models.Location, LocationSpecificationParameters>> _specifications;

        public LocationCollection(
            IEnumerable<ISpecification<Models.Location, LocationSpecificationParameters>> specifications)
        {
            _specifications = specifications;

            Values = new List<Models.Location>();
        }

        public void Add(Models.Location value, Models.Location referenceLocation, double thresholdDistance, int maxNumberOfValues)
        {
            if (Values.Count >= maxNumberOfValues) return;
            
            var parameters = new LocationSpecificationParameters
            {
                ReferenceLocation = referenceLocation,
                ThresholdDistance = thresholdDistance
            };
            if (_specifications.All(s => s.IsSatisfiedBy(value, parameters)))
                Values.Add(value);
        }
    }
}