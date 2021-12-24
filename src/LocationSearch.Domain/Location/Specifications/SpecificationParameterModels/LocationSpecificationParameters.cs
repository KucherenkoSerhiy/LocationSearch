namespace LocationSearch.Domain.Location.Specification.SpecificationParameterModels
{
    public class LocationSpecificationParameters
    {
        public Models.Location ReferenceLocation { get; set; }
        public double ThresholdDistance { get; set; }
    }
}