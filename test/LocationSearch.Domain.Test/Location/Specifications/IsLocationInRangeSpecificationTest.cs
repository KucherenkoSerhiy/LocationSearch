using LocationSearch.Domain.Location.Specification.SpecificationParameterModels;
using LocationSearch.Domain.Location.Specifications;
using NUnit.Framework;

namespace LocationSearch.Domain.Test.Location.Specifications
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class IsLocationInRangeSpecificationTest
    {
        [Test]
        public void IsSatisfiedBy_NullValue_ReturnsFalse()
        {
            var sut = new IsLocationInRangeSpecification();
            var isSatisfied = sut.IsSatisfiedBy(null, new LocationSpecificationParameters());
            Assert.IsFalse(isSatisfied);
        }

        [Test]
        public void IsSatisfiedBy_NullParameters_ReturnsFalse()
        {
            var sut = new IsLocationInRangeSpecification();
            var isSatisfied = sut.IsSatisfiedBy(new Domain.Location.Models.Location(), null);
            Assert.IsFalse(isSatisfied);
        }

        [Test]
        public void IsSatisfiedBy_OutOfRange_ReturnsFalse()
        {
            var value = new Domain.Location.Models.Location
            {
                Latitude = 0,
                Longitude = 0
            };
            var parameters = new LocationSpecificationParameters
            {
                ReferenceLocation = new Domain.Location.Models.Location
                {
                    Latitude = 1,
                    Longitude = 1
                },
                ThresholdDistance = 0
            };
            var sut = new IsLocationInRangeSpecification();
            var isSatisfied = sut.IsSatisfiedBy(value, parameters);
            Assert.IsFalse(isSatisfied);
        }

        [Test]
        public void IsSatisfiedBy_InRange_ReturnsTrue()
        {
            var value = new Domain.Location.Models.Location
            {
                Latitude = 0,
                Longitude = 0
            };
            var parameters = new LocationSpecificationParameters
            {
                ReferenceLocation = new Domain.Location.Models.Location
                {
                    Latitude = 0,
                    Longitude = 0
                },
                ThresholdDistance = 1
            };
            var sut = new IsLocationInRangeSpecification();
            var isSatisfied = sut.IsSatisfiedBy(value, parameters);
            Assert.IsTrue(isSatisfied);
        }
    }
}