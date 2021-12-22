using System.Threading.Tasks;
using LocationSearch.Application.Location.Models.Queries;
using LocationSearch.Application.Location.Models.Queries.Responses;
using LocationSearch.Location.Controllers;
using MediatR;
using Moq;
using NUnit.Framework;

namespace LocationSearch.API.Test.Location.Controllers
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LocationsControllerTest
    {
        [Test]
        public void GetLocationStatus_ValidRequest_Ok()
        {
            var query = new RetrieveLocationsQuery();
            var expectedResponse = new RetrieveLocationsQueryResponse();
            var sut = GetSut(out var mediatorMock);
            mediatorMock.Setup(m => m.Send(It.IsAny<RetrieveLocationsQuery>(), default)).Returns(Task.FromResult(expectedResponse));

            var currentResponse = sut.RetrieveLocations(query).Result.Value;
            
            Assert.AreSame(expectedResponse, currentResponse);
            mediatorMock.Verify(m => m.Send(It.IsAny<RetrieveLocationsQuery>(), default), Times.Once);
        }

        private static LocationsController GetSut(out Mock<IMediator> mediatorMock)
        {
            mediatorMock = new Mock<IMediator>(MockBehavior.Strict);
            return new LocationsController(mediatorMock.Object);
        }
    }
}