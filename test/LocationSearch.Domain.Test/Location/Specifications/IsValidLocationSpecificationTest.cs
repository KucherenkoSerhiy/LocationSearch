using LocationSearch.Domain.Location.Specification.SpecificationParameterModels;
using LocationSearch.Domain.Location.Specifications;
using NUnit.Framework;

namespace LocationSearch.Domain.Test.Location.Specifications
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class IsValidLocationSpecificationTest
    {
        [Test]
        public void IsSatisfiedBy_NullValue_ReturnsFalse()
        {
            var sut = new IsValidLocationSpecification();
            var isSatisfied = sut.IsSatisfiedBy(null, new LocationSpecificationParameters());
            Assert.IsFalse(isSatisfied);
        }
        
        [Test]
        public void IsSatisfiedBy_NotNullValue_ReturnsTrue()
        {
            var sut = new IsValidLocationSpecification();
            var isSatisfied = sut.IsSatisfiedBy(new Domain.Location.Models.Location(), new LocationSpecificationParameters());
            Assert.IsTrue(isSatisfied);
        }
    }
}