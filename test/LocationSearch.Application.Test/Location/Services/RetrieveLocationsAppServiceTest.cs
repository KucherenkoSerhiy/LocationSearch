using System.Collections.Generic;
using System.Threading.Tasks;
using LocationSearch.Application.Location.Services.Impl;
using LocationSearch.Domain.Location.Models;
using LocationSearch.Domain.Location.Services;
using Moq;
using NUnit.Framework;

namespace LocationSearch.Application.Test.Location.Services
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RetrieveLocationsAppServiceTest
    {
        [Test]
        public void Retrieve_InvalidRequest_Throws()
        {
            // TODO
        }
        
        [Test]
        public void Retrieve_ValidRequest_Ok()
        {
            var parameters = new LocationQueryParams();
            var locations = new List<Domain.Location.Models.Location>();
            
            var sut = GetSut(out var retrieveLocationsDomainService);
            retrieveLocationsDomainService.Setup(x => x.Retrieve(parameters)).Returns(() => Task.FromResult(locations));
            
            var actualLocations = sut.Retrieve(parameters).Result;
            
            Assert.AreSame(locations, actualLocations);
            retrieveLocationsDomainService.Verify(x => x.Retrieve(parameters), Times.Once);
        }

        private static RetrieveLocationsAppService GetSut(out Mock<IRetrieveLocationsDomainService> retrieveLocationsDomainService)
        {
            retrieveLocationsDomainService = new Mock<IRetrieveLocationsDomainService>(MockBehavior.Strict);
            return new RetrieveLocationsAppService(retrieveLocationsDomainService.Object);
        }
    }
}