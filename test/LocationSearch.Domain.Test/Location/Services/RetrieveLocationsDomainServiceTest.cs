using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var query = "SELECT * FROM LOCATION";
            var locations = new List<Domain.Location.Models.Location>();

            var sut = GetSut(out var queryBuilderMock, out var queryRunnerMock);
            queryBuilderMock.Setup(x => x.Build(parameters)).Returns(Task.FromResult(query));
            queryRunnerMock.Setup(x => x.Run(query)).Returns(Task.FromResult(locations));

            var actualLocations = sut.Retrieve(parameters).Result;
            
            Assert.AreSame(locations, actualLocations);
            
            queryBuilderMock.Verify(x => x.Build(parameters), Times.Once);
            queryRunnerMock.Verify(x => x.Run(query), Times.Once);
        }

        private static RetrieveLocationsDomainService GetSut(
            out Mock<IRetrieveQueryBuilder<LocationQueryParams, string>> queryBuilderMock,
            out Mock<IRetrieveQueryRunner<string, List<Domain.Location.Models.Location>>> queryRunnerMock)
        {
            queryBuilderMock = new Mock<IRetrieveQueryBuilder<LocationQueryParams, string>>(MockBehavior.Strict);
            queryRunnerMock =
                new Mock<IRetrieveQueryRunner<string, List<Domain.Location.Models.Location>>>(MockBehavior.Strict);
            return new RetrieveLocationsDomainService(queryBuilderMock.Object, queryRunnerMock.Object);
        }
    }
}