using Core.Patterns;
using LocationSearch.Domain.Location.Specification.SpecificationParameterModels;

namespace LocationSearch.Domain.Location.Specifications
{
    public class IsValidLocationSpecification: ISpecification<Models.Location, LocationSpecificationParameters>
    {
        public bool IsSatisfiedBy(Models.Location value, LocationSpecificationParameters parameters)
        {
            return value != null;
        }
    }
}