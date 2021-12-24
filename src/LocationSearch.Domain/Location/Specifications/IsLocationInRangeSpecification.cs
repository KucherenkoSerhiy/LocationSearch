using Core.Patterns;
using LocationSearch.Domain.Location.Specification.SpecificationParameterModels;

namespace LocationSearch.Domain.Location.Specifications
{
    public class IsLocationInRangeSpecification : ISpecification<Models.Location, LocationSpecificationParameters>
    {
        public bool IsSatisfiedBy(Models.Location value, LocationSpecificationParameters parameters)
        {
            if (value == null || parameters?.ReferenceLocation == null)
                return false;

            var distance = value.CalculateDistance(parameters.ReferenceLocation);
            return distance <= parameters.ThresholdDistance;
        }
    }
}