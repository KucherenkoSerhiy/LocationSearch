using System.Collections.Generic;
using Core.Patterns;
using LocationSearch.Domain.Location.Collections.Impl;
using LocationSearch.Domain.Location.Specification.SpecificationParameterModels;
using Moq;
using NUnit.Framework;

namespace LocationSearch.Domain.Test.Location.Collections
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LocationCollectionTest
    {
        [Test]
        public void Add_InvalidValue_DoesNotAdd()
        {
            var valueToAdd = new Domain.Location.Models.Location();
            
            var sut = this.GetSut(out var specificationMock);
            specificationMock.Setup(x => x.IsSatisfiedBy(valueToAdd, It.IsAny<LocationSpecificationParameters>()))
                .Returns(false);
            
            sut.Add(valueToAdd, null, 0);
            
            Assert.AreEqual(0, sut.Values.Count);
        }

        [Test]
        public void Add_ValidValue_Adds()
        {
            var valueToAdd = new Domain.Location.Models.Location();
            
            var sut = this.GetSut(out var specificationMock);
            specificationMock.Setup(x => x.IsSatisfiedBy(valueToAdd, It.IsAny<LocationSpecificationParameters>()))
                .Returns(true);
            
            sut.Add(valueToAdd, null, 0);
            
            Assert.AreEqual(1, sut.Values.Count);
            Assert.AreSame(valueToAdd, sut.Values[0]);
        }

        private LocationCollection GetSut(
            out Mock<ISpecification<Domain.Location.Models.Location, LocationSpecificationParameters>> specificationMock)
        {
            specificationMock =
                new Mock<ISpecification<Domain.Location.Models.Location, LocationSpecificationParameters>>(MockBehavior
                    .Strict);
            var sut = new LocationCollection(
                new List<ISpecification<Domain.Location.Models.Location, LocationSpecificationParameters>>
                    {specificationMock.Object});
            return sut;
        }
    }
}