using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Patterns;
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
            var parameters = new LocationQueryParams();
            
            var sut = GetSut(out _, out var locationQueryParamsValidatorMocks);
            locationQueryParamsValidatorMocks[0].Setup(x => x.Validate(It.IsAny<LocationQueryParams>())).Throws<ArgumentNullException>();
            
            var exception = Assert.Throws<AggregateException>(() => { var _ = sut.Retrieve(parameters).Result; });
            
            Assert.IsNotNull(exception.InnerException);
            Assert.IsInstanceOf<ArgumentNullException>(exception.InnerException);
            
            locationQueryParamsValidatorMocks[0].Verify(x => x.Validate(It.IsAny<LocationQueryParams>()), Times.Once);
        }
        
        [Test]
        public void Retrieve_ValidRequest_Ok()
        {
            var parameters = new LocationQueryParams();
            var locations = new List<Domain.Location.Models.Location>();
            
            var sut = GetSut(
                out var retrieveLocationsDomainService,
                out var locationQueryParamsValidatorMocks);
            retrieveLocationsDomainService.Setup(x => x.Retrieve(parameters)).Returns(() => Task.FromResult(locations));
            locationQueryParamsValidatorMocks[0].Setup(x => x.Validate(It.IsAny<LocationQueryParams>()));
            
            var actualLocations = sut.Retrieve(parameters).Result;
            
            Assert.AreSame(locations, actualLocations);
            retrieveLocationsDomainService.Verify(x => x.Retrieve(parameters), Times.Once);
            locationQueryParamsValidatorMocks[0].Verify(x => x.Validate(It.IsAny<LocationQueryParams>()), Times.Once);
        }

        private static RetrieveLocationsAppService GetSut(
            out Mock<IRetrieveLocationsDomainService> retrieveLocationsDomainService,
            out List<Mock<IRequestValidator<LocationQueryParams>>> locationQueryParamsValidatorMocks)
        {
            retrieveLocationsDomainService = new Mock<IRetrieveLocationsDomainService>(MockBehavior.Strict);
            locationQueryParamsValidatorMocks = new List<Mock<IRequestValidator<LocationQueryParams>>>
            {
                new Mock<IRequestValidator<LocationQueryParams>>(MockBehavior.Strict)
            };
            return new RetrieveLocationsAppService(
                retrieveLocationsDomainService.Object,
                locationQueryParamsValidatorMocks.Select(x => x.Object));
        }
    }
}