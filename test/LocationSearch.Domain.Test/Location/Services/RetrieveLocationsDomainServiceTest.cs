using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationSearch.Domain.Location.Collections;
using LocationSearch.Domain.Location.Models;
using LocationSearch.Domain.Location.Services;
using LocationSearch.Domain.Location.Services.Impl;
using Moq;
using NUnit.Framework;

namespace LocationSearch.Domain.Test.Location.Services
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RetrieveLocationsDomainServiceTest
    {
        [Test]
        public void Retrieve_ValidRequest_Ok()
        {
            var parameters = new LocationQueryParams();
            var locations = new List<Domain.Location.Models.Location>();

            var sut = GetSut(out var locationsDataMock, out var locationCollectionMock);
            locationsDataMock.Setup(x => x.Read(parameters)).Returns(Task.CompletedTask);
            locationCollectionMock.SetupGet(x => x.Values).Returns(locations);

            var actualLocations = sut.Retrieve(parameters).Result;
            
            Assert.AreSame(locations, actualLocations);
            
            locationsDataMock.Verify(x => x.Read(parameters), Times.Once);
            locationCollectionMock.VerifyGet(x => x.Values, Times.Once);
        }

        private static RetrieveLocationsDomainService GetSut(
            out Mock<IRetrieveLocationsData<LocationQueryParams>> locationsDataMock,
            out Mock<ILocationCollection> locationCollectionMock)
        {
            locationsDataMock = new Mock<IRetrieveLocationsData<LocationQueryParams>>(MockBehavior.Strict);
            locationCollectionMock = new Mock<ILocationCollection>(MockBehavior.Strict);
            
            return new RetrieveLocationsDomainService(locationsDataMock.Object, locationCollectionMock.Object);
        }
    }
}