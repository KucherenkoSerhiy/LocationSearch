using System.Collections.Generic;
using System.Threading.Tasks;
using LocationSearch.Domain.Location.Models;
using LocationSearch.Domain.Location.Services;

namespace LocationSearch.Application.Location.Services.Impl
{
    public class RetrieveLocationsAppService : IRetrieveLocationsAppService
    {
        private readonly IRetrieveLocationsDomainService _retrieveLocationsDomainService;

        public RetrieveLocationsAppService(IRetrieveLocationsDomainService retrieveLocationsDomainService)
        {
            _retrieveLocationsDomainService = retrieveLocationsDomainService;
        }
        
        public async Task<List<Domain.Location.Models.Location>> Retrieve(LocationQueryParams parameters)
        {
            // TODO: validation usage goes here

            var locations = await _retrieveLocationsDomainService.Retrieve(parameters);

            return locations;
        }
    }
}