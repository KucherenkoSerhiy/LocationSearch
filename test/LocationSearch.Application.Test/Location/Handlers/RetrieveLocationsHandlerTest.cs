using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LocationSearch.Application.Location.Models.Handlers;
using LocationSearch.Application.Location.Models.Queries;
using LocationSearch.Application.Location.Models.Queries.Responses;
using LocationSearch.Application.Location.Models.Services;
using LocationSearch.Domain.Location.Models;
using Moq;
using NUnit.Framework;

namespace LocationSearch.Application.Test.Location.Handlers
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RetrieveLocationsHandlerTest
    {
        [Test]
        public void Handle_ValidRequest_Ok()
        {
            var queryParameters = new LocationQueryParams();
            var query = new RetrieveLocationsQuery
            {
                Parameters = queryParameters
            };
            var locations = new List<Domain.Location.Models.Location>();
            var response = new RetrieveLocationsQueryResponse
            {
                Locations = locations
            };

            var sut = GetSut(out var startLocationAppServiceMock);
            startLocationAppServiceMock
                .Setup(x => x.Retrieve(queryParameters))
                .Returns(() => Task.FromResult(locations));

            var actualResponse = sut.Handle(query, CancellationToken.None).Result;

            Assert.AreSame(response.Locations, actualResponse.Locations);
            startLocationAppServiceMock.Verify(x => x.Retrieve(queryParameters), Times.Once);
        }

        private static RetrieveLocationsQueryHandler GetSut(
            out Mock<IRetrieveLocationsAppService> retrieveLocationsAppService)
        {
            retrieveLocationsAppService = new Mock<IRetrieveLocationsAppService>(MockBehavior.Strict);
            return new RetrieveLocationsQueryHandler(retrieveLocationsAppService.Object);
        }
    }
}